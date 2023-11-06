using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
