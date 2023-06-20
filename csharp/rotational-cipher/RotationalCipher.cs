using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder builder = new();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                char encryptedChar = (char)(((c - baseChar) + shiftKey) % 26 + baseChar);
                builder.Append(encryptedChar);
            }
            else
            {
                builder.Append(c);
            }
        }

        return builder.ToString();
    }
}
