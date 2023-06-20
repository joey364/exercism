using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private const string banner =
        @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        const int linelength = 61;
        const int spaces = (linelength - 1) / 2 - 1;

        return $"{studentA,spaces} ♡ {studentB,-spaces}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return string.Format(banner, studentA, studentB);
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        FormattableString fs = $"{studentA} and {studentB} have been dating since {start:d} - that's {hours:n2} hours";
        return fs.ToString(CultureInfo.CreateSpecificCulture("de-DE"));
    }
}
