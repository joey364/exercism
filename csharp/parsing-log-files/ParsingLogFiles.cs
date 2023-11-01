using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        const string pattern = @"^(\[TRC\] | \[DBG\] | \[INF\] | \[ERR\] | \[WRN\] | \[FTL\])";
        return  Regex.IsMatch(text, pattern,  RegexOptions.IgnorePatternWhitespace);
    }

    public string[] SplitLogLine(string text)
    {
        var pattern = @"<[*^=-]*>";
        return new Regex(pattern).Split(text);
    }

    public int CountQuotedPasswords(string lines)
    {
        bool[] results = new bool[lines.Length];
        var regex = new Regex(@""".*password.*""",
            RegexOptions.IgnoreCase | RegexOptions.Multiline);
        var matches = regex.Matches(lines);
        return matches.Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d+", "", RegexOptions.IgnoreCase);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var pattern = @".*\s(?<pw>password\S+).*";

        string[] outlines = new string[lines.Length];
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        for (int i = 0; i < lines.Length; i++)
        {
            var matches = regex.Matches(lines[i]);
            if (matches.Count > 0)
            {
                var grps = matches[0].Groups;
                outlines[i]
                  = $"{grps["pw"].Value}: {lines[i]}";
            }
            else
            {
                outlines[i] = $"--------: {lines[i]}";
            }
        }

        return outlines;
    }
}
