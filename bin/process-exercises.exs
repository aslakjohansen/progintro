#!/usr/bin/env elixir

Mix.install([:yaml_elixir])

defmodule Script do
  @alines "exercises/answers.tex"
  
  def expand_includes(text, basepath) do
    case Regex.run(~r/^(.*\\input{)([^}#]*)(}.*)$/sU, text) do
      [_, before, match, rest] ->
        processed_rest =
          rest
          |> expand_includes(basepath)
        
        case match do
        "exercises/answers.tex" ->
          before<>match<>processed_rest
        _ ->
          processed_match =
            match
            |> File.read!()
            |> expand_includes(basepath)
          before<>processed_match<>processed_rest
        end
      nil -> text
    end
  end
  
  def extract_worklist(text, results\\[]) do
    case Regex.run(~r/^(.*\\exercises{)([^}]*)}{([^}]*)(}.*)$/sU, text) do
      [_, _before, shorthand, title, rest] ->
        task = %{
          shorthand: shorthand,
          title: title,
          qfilename: "exercises/#{shorthand}.tex",
          afilename: @alines,
        }
        extract_worklist(rest, [task|results])
      nil -> results
    end
  end
  
  def process_exercise(topic, exercise) do
    IO.puts(exercise)
    
    meta =
      "../ex/#{topic}/#{exercise}/meta.yaml"
      |> File.read!()
      |> YamlElixir.read_from_string!(atoms: true)
      |> Enum.map(fn {k,v} -> {String.to_atom(k), v} end)
      |> Map.new()
    
    qfile = "../ex/#{topic}/#{exercise}/question.tex"
    afile = "../ex/#{topic}/#{exercise}/answer.tex"
    
    {
      """
      \\subsection{#{meta.title}}
      \\label{q:#{topic}:#{exercise}}
      \\input{#{qfile}}
      """,
      """
      \\subsection{#{meta.title}}
      \\label{a:#{topic}:#{exercise}}
      \\input{#{afile}}
      """
    }
  end
  
  def process(task) do
    %{
      shorthand: shorthand,
      title: title,
      qfilename: qfilename,
      afilename: afilename,
    } = task
    
    # read order
    order =
      "../ex/#{shorthand}/order.yaml"
      |> File.read!()
      |> YamlElixir.read_from_string!()
    
    qlines = """
    \\section{Exercises}
    \\label{q:#{shorthand}}
    """
    
    alines = """
    \\section{#{title}}
    \\label{a:#{shorthand}}
    """
    
    {qlines, alines} =
      order
      |> Enum.reduce({qlines, alines}, fn exercise, {qlines, alines} ->
        {exqlines, exalines} = process_exercise(shorthand, exercise)
        {qlines<>exqlines, alines<>exalines}
      end)
    
    :ok =
      qfilename
      |> File.write(qlines)
    
    :ok =
      afilename
      |> File.write(alines, [:append])
  end
  
  def run() do
    case System.argv() do
    [root_input, basepath] ->
      File.rm(@alines)
      
      root_input
      |> File.read!()
      |> expand_includes(basepath)
      |> extract_worklist()
      |> Enum.map(&process/1)
    _ ->
      IO.puts("Syntax: process-exercises.exs ROOT_INPUT_FILE BASE_PATH")
    end
  end
end

Script.run()
