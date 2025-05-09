defmodule HelloCompiledTest do
  use ExUnit.Case
  doctest HelloCompiled

  test "greets the world" do
    assert HelloCompiled.hello() == :world
  end
end
