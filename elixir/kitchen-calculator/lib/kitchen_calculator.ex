defmodule KitchenCalculator do
  def get_volume(volume_pair) do
    {_, volume} = volume_pair
    volume
  end

  def to_milliliter(volume_pair) do
    {unit, value} = volume_pair

    case {unit, value} do
      {:cup, value} -> {:milliliter, value * 240}
      {:fluid_ounce, value} -> {:milliliter, value * 30}
      {:teaspoon, value} -> {:milliliter, value * 5}
      {:tablespoon, value} -> {:milliliter, value * 15}
      {:milliliter, value} -> {:milliliter, value}
      _ -> "none"
    end
  end

  def from_milliliter(volume_pair, unit) do
    {_, value} = volume_pair

    case {unit, value} do
      {:cup, value} -> {unit, value / 240}
      {:fluid_ounce, value} -> {unit, value / 30}
      {:teaspoon, value} -> {unit, value / 5}
      {:tablespoon, value} -> {unit, value / 15}
      {:milliliter, value} -> {unit, value}
      _ -> "none"
    end
  end

  def convert(volume_pair, unit) do
    to_milliliter(volume_pair) |> from_milliliter(unit)
  end
end
