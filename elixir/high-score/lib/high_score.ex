defmodule HighScore do
  @default_socre 0
  def new() do
    Map.new()
  end

  def add_player(scores, name, score \\ @default_socre) do
    Map.put(scores, name, score)
  end

  def remove_player(scores, name) do
    Map.delete(scores, name)
  end

  def reset_score(scores, name) do
    Map.put(scores, name, @default_socre)
  end

  def update_score(scores, name, score) do
    Map.update(scores, name, score, &(&1 + score))
    # Map.update(scores, name, score, fn val -> score + val end)
  end

  def get_players(scores) do
    Map.keys(scores)
  end
end
