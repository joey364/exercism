defmodule HighSchoolSweetheart do
  def first_letter(name) do
    String.trim(name) |> String.first()
  end

  def initial(name) do
    (first_letter(name) <> ".") |> String.upcase()
  end

  def initials(full_name) do
    [first, last] = String.split(full_name)
    initial(first) <> " " <> initial(last)
  end

  def pair(full_name1, full_name2) do
    template = """
         ******       ******
       **      **   **      **
     **         ** **         **
    **            *            **
    **                         **
    **     X. X.  +  X. X.     **
     **                       **
       **                   **
         **               **
           **           **
             **       **
               **   **
                 ***
                  *
    """

    String.replace(template, "X. X.", initials(full_name1), global: false)
    |> String.replace("X. X.", initials(full_name2), global: false)
  end
end
