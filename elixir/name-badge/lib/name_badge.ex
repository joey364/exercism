defmodule NameBadge do
  def print(id, name, department) do
    id_part = if id, do: "[#{id}] - ", else: ""
    dept_part = if department, do: " - " <> String.upcase(department), else: " - OWNER"
    id_part <> name <> dept_part
  end
end
