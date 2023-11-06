using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        var isQuestion = statement.TrimEnd().EndsWith("?");
        var isYelling = statement.Any(char.IsLetter) && statement.ToUpperInvariant() == statement;
        var isYellingQuestion = isQuestion && isYelling;
        var isSilence = string.IsNullOrWhiteSpace(statement);

        if (isSilence)
        {
            return "Fine. Be that way!";
        }
        else if (isYellingQuestion)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (isYelling)
        {
            return "Whoa, chill out!";
        }
        else if (isQuestion)
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }

    }
}
