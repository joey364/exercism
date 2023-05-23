using System;

public static class LogAnalysis
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        string[] substrings = str.Split(delimiter);
        return substrings[substrings.Length - 1];
    }

    public static string SubstringBetween(this string str, string start, string end)
    {
        int startIdx = str.IndexOf(start) + start.Length,
            endIdx = str.LastIndexOf(end);
        return str.Substring(startIdx, endIdx - startIdx);
    }

    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}
