import Bitwise

defmodule Secrets do
  def secret_add(secret) do
    fn val -> secret + val end
  end

  def secret_subtract(secret) do
    fn val -> val - secret end
  end

  def secret_multiply(secret) do
    fn val -> val * secret end
  end

  def secret_divide(secret) do
    fn val -> (val / secret) |> trunc() end
  end

  def secret_and(secret) do
    fn val -> band(val, secret) end
  end

  def secret_xor(secret) do
    fn val -> bxor(val, secret) end
  end

  def secret_combine(secret_function1, secret_function2) do
    fn val -> secret_function2.(secret_function1.(val)) end
  end
end
