#!/usr/bin/env elixir

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
  
  def process(task) do
    %{
      shorthand: shorthand,
      title: title,
      qfilename: qfilename,
      afilename: afilename,
    } = task
    
    qlines = """
    \\section{Exercises}
    \\label{q:#{shorthand}}
    """
    
    alines = """
    \\section{#{title}}
    \\label{a:#{shorthand}}
    """
    
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
