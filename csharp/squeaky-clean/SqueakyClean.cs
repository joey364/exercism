using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var builder = new StringBuilder();
        bool isAfterDash = false;

        foreach (char c in identifier)
        {
            if (isAfterDash)
                builder.Append(char.ToUpperInvariant(c));
            if (char.IsWhiteSpace(c))
                builder.Append("_");
            if (char.IsControl(c))
                builder.Append("CTRL");
            if (char.IsLetter(c) && !isAfterDash)
                builder.Append(c);

            isAfterDash = c.Equals('-');
        }
        return Regex.Replace(builder.ToString(), "[α-ω]", "");
    }
}
