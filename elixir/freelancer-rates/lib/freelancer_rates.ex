defmodule FreelancerRates do
  def daily_rate(hourly_rate) do
    hourly_rate * 8.0
  end

  def apply_discount(before_discount, discount) do
    before_discount * ((100 - discount) / 100)
  end

  def monthly_rate(hourly_rate, discount) do
    apply_discount(daily_rate(hourly_rate) * 22.0, discount) |> ceil()
  end

  def days_in_budget(budget, hourly_rate, discount) do
    price = daily_rate(hourly_rate) |> apply_discount(discount)
    (budget / price) |> Float.floor(1)
  end
end
