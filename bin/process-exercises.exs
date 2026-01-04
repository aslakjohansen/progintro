#!/usr/bin/env elixir

Mix.install([:yaml_elixir, :jason])

defmodule Script do
  @alines "exercises/answers.tex"
  @base_feedback_url "https://www.asjo.dk/teaching/oop/feedback?params="

  def collect_common_data() do
    # hostname
    {:ok, cl} = :inet.gethostname()
    hostname = List.to_string(cl)

    # username
    username =
      case :os.type() do
        {:unix, _} -> "USER"
        {:win32, _} -> "USERNAME"
      end
      |> System.get_env()

    %{
      time: DateTime.now!("Etc/UTC") |> DateTime.to_unix(),
      wd: File.cwd!(),
      argv: System.argv(),
      hostname: hostname,
      username: username,
      git_branches: System.cmd("git", ["branch", "-a"]) |> elem(0),
      git_branch_active: System.cmd("git", ["branch"]) |> elem(0),
      git_diff_linecount:
        System.cmd("git", ["diff"]) |> elem(0) |> String.split("\n") |> length(),
      git_last_commit_id:
        System.cmd("git", ["log"]) |> elem(0) |> String.split("\n") |> Enum.at(0),
      git_last_commit_author:
        System.cmd("git", ["log"]) |> elem(0) |> String.split("\n") |> Enum.at(1),
      git_last_commit_time:
        System.cmd("git", ["log"]) |> elem(0) |> String.split("\n") |> Enum.at(2),
      git_last_commit_summary:
        System.cmd("git", ["log"]) |> elem(0) |> String.split("\n") |> Enum.at(4),
      git_remotes: System.cmd("git", ["remote", "-v"]) |> elem(0),
      git_config_user_name: System.cmd("git", ["config", "get", "user.name"]) |> elem(0),
      git_config_user_email: System.cmd("git", ["config", "get", "user.email"]) |> elem(0),
      git_config_remote_origin_url:
        System.cmd("git", ["config", "get", "remote.origin.url"]) |> elem(0)
    }
  end

  def expand_includes(text, basepath) do
    case Regex.run(~r/^(.*\\input{)([^}#]*)(}.*)$/sU, text) do
      [_, before, match, rest] ->
        processed_rest =
          rest
          |> expand_includes(basepath)

        case match do
          "exercises/answers.tex" ->
            before <> match <> processed_rest

          _ ->
            processed_match =
              match
              |> File.read!()
              |> expand_includes(basepath)

            before <> processed_match <> processed_rest
        end

      nil ->
        text
    end
  end

  def extract_worklist(text, results \\ []) do
    case Regex.run(~r/^(.*\\exercises{)([^}]*)}{([^}]*)(}.*)$/sU, text) do
      [_, _before, topic, title, rest] ->
        task = %{
          topic: topic,
          title: title,
          qfilename: "exercises/#{topic}.tex",
          afilename: @alines
        }

        extract_worklist(rest, [task | results])

      nil ->
        results
    end
  end

  def process_difficulty(topic, creativity, data) do
    params =
      data
      |> Jason.encode!()
      |> Base.encode64()

    """
    \\begin{tikzpicture}[remember picture,overlay]
      \\newcommand{\\halfvspacing}[0]{1.5mm}
      \\newcommand{\\hspacing}[0]{0.0mm}
      \\newcommand{\\barwidth}[0]{16mm}
      \\newcommand{\\fillcolor}[0]{teal!60}
      \\tikzstyle{bar}=[
        overlay,
        rectangle,
        draw=black,
        anchor=west,
        thick,
        text width=\\barwidth,
      ]
      
      \\coordinate (origin) at (140mm,8mm);
      
      \\node[anchor=east] () at ([xshift=-\\hspacing,yshift= \\halfvspacing]origin) {\\footnotesize Topic};
      \\node[anchor=east] () at ([xshift=-\\hspacing,yshift=-\\halfvspacing]origin) {\\footnotesize Creativity};
      
      \\node[rectangle, fill=\\fillcolor, anchor=west, text width=#{topic}*\\barwidth] () at ([yshift= \\halfvspacing]origin) {};
      \\node[rectangle, fill=\\fillcolor, anchor=west, text width=#{creativity}*\\barwidth] () at ([yshift=-\\halfvspacing]origin) {};
      
      \\node[bar] () at ([yshift= \\halfvspacing]origin) {};
      \\node[bar] () at ([yshift=-\\halfvspacing]origin) {};
      
      %\\node[anchor=west] () at ([xshift=3mm+\\barwidth,yshift=0]origin) {\\footnotesize \\pdftooltip{\\href{#{@base_feedback_url}#{params}}{feedback}}{Give feedback!}};
    \\end{tikzpicture}
    \\vspace{-3mm}
    """
  end

  def process_exercise(topic, exercise, data) do
    data =
      Map.merge(data, %{
        type: "exercise",
        segment: topic,
        entry: exercise
      })

    IO.puts(exercise)

    meta =
      "../ex/#{topic}/#{exercise}/meta.yaml"
      |> File.read!()
      |> YamlElixir.read_from_string!(atoms: true)
      |> Enum.map(fn {k, v} -> {String.to_atom(k), v} end)
      |> Map.new()

    context = "../ex/#{topic}/#{exercise}/"
    qfile = "#{context}/question.tex"
    afile = "#{context}/answer.tex"
    difficulty = process_difficulty(meta.difficulty_topic, meta.difficulty_creativity, data)

    {
      """
      \\renewcommand{\\context}[0]{#{context}}
      %\\subsection{#{meta.title}}
      %\\label{q:#{topic}:#{exercise}}
      \\begin{exercise}{#{topic}}{#{exercise}}{#{meta.title}}
      #{difficulty}
      \\input{#{qfile}}
      \\end{exercise}
      """,
      """
      \\renewcommand{\\context}[0]{#{context}}
      %\\subsection{#{meta.title}}
      %\\label{a:#{topic}:#{exercise}}
      \\begin{solution}{#{topic}}{#{exercise}}{#{meta.title}}
      \\input{#{afile}}
      \\end{solution}
      """
    }
  end

  def process(task, data) do
    %{
      topic: topic,
      title: title,
      qfilename: qfilename,
      afilename: afilename
    } = task

    # read order
    order =
      "../ex/#{topic}/order.yaml"
      |> File.read!()
      |> YamlElixir.read_from_string!()

    qlines = """
    \\section{Exercises}
    \\label{q:#{topic}}
    """

    alines = """
    \\section{#{title}}
    \\label{a:#{topic}}
    """

    {qlines, alines} =
      order
      |> Enum.reduce({qlines, alines}, fn exercise, {qlines, alines} ->
        data = Map.merge(data, task)
        {exqlines, exalines} = process_exercise(topic, exercise, data)
        {qlines <> exqlines, alines <> exalines}
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
        data = collect_common_data()

        root_input
        |> File.read!()
        |> expand_includes(basepath)
        |> extract_worklist()
        |> Enum.reverse()
        |> Enum.map(fn task -> process(task, data) end)

      _ ->
        IO.puts("Syntax: process-exercises.exs ROOT_INPUT_FILE BASE_PATH")
    end
  end
end

Script.run()
