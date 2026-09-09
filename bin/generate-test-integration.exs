#!/usr/bin/env elixir

defmodule Script do
  @canvas_width 160
  @canvas_height 70
  @offset 4
  
  defp print_syntax() do
    IO.puts("Syntax: integration-test-processer.exs INPUT_FILENAME SHAPEDEF OUTPUT_FILENAME")
    IO.puts("        integration-test-processer.exs templates/integration_test_source.graphml n15-n17-n16-n18,n24-n23-n22-n25 templates/inheritance_abstract.tex")
  end
  
  def parse_shapecode(shapecode) do
    shapecode
    |> String.split(",")
    |> Enum.map(fn entry -> entry |> String.split("-") end)
  end
  
  defp tag2properties(tag) do
    tag
    |> String.trim_trailing("/>")
    |> String.trim_trailing(">")
    |> String.split(" ")
    |> Enum.filter(fn element -> element != "" end)
    |> Enum.slice(1..-1//1)
    |> Enum.map(fn input ->
        [_, key, value] = Regex.run(~r/^([^\=]+)\=\"([^\""]+)\"$/, input)
        {key, value}
      end)
    |> Map.new()
  end
  
  defp boring_float2string(f) do
    f
    |> :erlang.float_to_binary([:compact, decimals: 20])
  end
  
  defp shift_line(offset, {_id1, %{x: x1, y: y1}}, {_id2, %{x: x2, y: y2}}) do
    dx = x2-x1
    dy = y2-y1
    l = :math.sqrt(dx**2 + dy**2)
    
    ndx = -1*dy/l
    ndy =    dx/l
    
    {
      %{x: x1 + offset*ndx, y: y1 + offset*ndy},
      %{x: x2 + offset*ndx, y: y2 + offset*ndy}
    }
  end
  
  defp offset_node({{_, %{x: _, y: _}} = p1, {_id2, %{x: _, y: _}} = p2, {_, %{x: _, y: _}} = p3}) do
    {l1_p1, l1_p2} = @offset |> shift_line(p1, p2)
    {l2_p1, l2_p2} = @offset |> shift_line(p2, p3)
    
    l1_a = (l1_p2.y-l1_p1.y) / (l1_p2.x-l1_p1.x)
    l2_a = (l2_p2.y-l2_p1.y) / (l2_p2.x-l2_p1.x)
    l1_b = l1_p1.y - (l1_a*l1_p1.x)
    l2_b = l2_p1.y - (l2_a*l2_p1.x)
    
    x = (l2_b-l1_b) / (l1_a-l2_a)
    y = l1_a * x + l1_b
    
    "#{boring_float2string(x)}mm,#{boring_float2string(y)}mm"
  end
  
  defp load(filename) do
    initial_nodes = %{}
    initial_edges = []
    current_node = Node
    
    {:ok, contents} = File.read(filename)
    {nodes, edges, _} =
      contents
      |> String.split("\n")
      |> Enum.reduce({initial_nodes, initial_edges, current_node},
        fn line, {nodes, edges, current_node} ->
          line = line |> String.trim()
          case line do
            "<node"<>_rest ->
              props = tag2properties(line)
              id = Map.get(props, "id")
              current_node = %{}
              {nodes |> Map.put(id, current_node), edges, id}
            "<edge"<>_rest ->
              props = tag2properties(line)
              edge = %{
                id:  Map.get(props, "id"),
                src: Map.get(props, "source"),
                dst: Map.get(props, "target"),
              }
              {nodes, [edge|edges], current_node}
            "<y:Geometry"<>_rest ->
              props = tag2properties(line)
              new_data = %{
                x: Map.get(props, "x") |> String.to_float(),
                y: Map.get(props, "y") |> String.to_float(),
              }
              nodes =
                nodes
                |> Map.update!(current_node, fn data -> data |> Map.merge(new_data) end)
              {nodes, edges, current_node}
            _ ->
            {nodes, edges, current_node}
          end
        end)
    %{nodes: nodes, edges: edges}
  end
  
  defp remap_coordinate_system(%{nodes: nodes, edges: edges}) do
    {xmin, xmax} = nodes |> Enum.map(fn {_id, n} -> n.x end) |> Enum.min_max()
    {ymin, ymax} = nodes |> Enum.map(fn {_id, n} -> n.y end) |> Enum.min_max()
    xscale = @canvas_width  / (xmax - xmin)
    yscale = @canvas_height / (ymax - ymin)
    {xscaler, yscaler} =
      cond do
        xscale > yscale ->
          {
            fn offset -> (xmax-offset)*yscale end,
            fn offset -> (ymax-(offset-ymin))*yscale end
          }
        true ->
          {
            fn offset -> (xmax-offset)*xscale end,
            fn offset -> (ymax-(offset-ymin))*xscale end
          }
      end
    
    nodes =
      nodes
      |> Enum.map(fn {id, props} ->
          {id, Map.merge(props, %{x: xscaler.(props.x), y: yscaler.(props.y)})}
        end)
      |> Map.new()
    
    %{nodes: nodes, edges: edges}
  end
  
  defp calc_shape(%{nodes: nodes, edges: edges}, shapedefs) do
    cells =
      shapedefs
      |> Enum.map(fn [h|_t] = sequence ->
          [Enum.at(sequence, -1)|sequence++[h]]
          |> Enum.map(fn id -> {id, Map.get(nodes, id)} end)
          |> Enum.chunk_every(3, 1, :discard)
          |> Enum.map(fn triple -> triple |> List.to_tuple() |> offset_node() end)
        end)
    %{nodes: nodes, edges: edges, cells: cells}
  end
  
  defp tikzify(%{nodes: nodes, edges: edges, cells: cells}) do
    node_code =
      nodes
      |> Enum.map(fn {id, %{x: x, y: y}} ->
          "\\node[node] (#{id}) at (#{x}mm, #{y}mm) {};"
        end)
      |> Enum.join("\n")
    edge_code =
      edges
      |> Enum.map(fn data -> "\\draw[edge] (#{data.src}) -- (#{data.dst});" end)
      |> Enum.join("\n")
    last_slide = length(cells)+2
    cell_code =
      cells
      |> Enum.reduce({"", 2}, fn celldef, {lines,i} ->
          cell_code = celldef |> Enum.map(fn n -> "(#{n})" end) |> Enum.join(" -- ")
          
          {
            lines<>
            """
            %\\only<#{i},#{last_slide}>{
              \\draw[cell] #{cell_code} -- cycle;
            %}\n
            """,
            i+1
          }
        end)
      |> elem(0)
    
    """
    \\begin{center}
      \\begin{tikzpicture}
        \\newcommand{\\bgcolor}{white}
        \\tikzstyle{node} = [circle,very thick,draw=black,fill=\\bgcolor!90!black]
        \\tikzstyle{edge} = [overlay,very thick,draw=black]
        \\tikzstyle{cell} = [
          overlay,
          very thick,
          draw=purple,
          fill=purple!50!\\bgcolor,
          draw opacity=0.5,
          fill opacity=0.5,
          rounded corners=4mm,
        ]
        
        #{node_code}
        #{edge_code}
        #{cell_code}
      \\end{tikzpicture}
    \\end{center}
    """
  end
  
  defp store(lines, filename) do
    filename
    |> File.write!(lines)
  end
  
  def run do
    try do
      [ifilename, shapecode, ofilename] = System.argv()
      
      ifilename
      |> load()
      |> remap_coordinate_system()
      |> calc_shape(shapecode |> parse_shapecode())
      |> tikzify()
      |> store(ofilename)
    rescue
      _e in MatchError -> print_syntax();
    end
  end
end

Script.run()

