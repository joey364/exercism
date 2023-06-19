using System;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        char currentChar, lookahead;
        int count = 1;
        string encoded = "";

        for (int i = 0; i < input.Length; i++)
        {
            currentChar = input[i];
            // lookahead = input[i + 1];
            lookahead = i + 1 == input.Length ? '0' : input[i + 1];
            if (currentChar == lookahead)
            {
                count++;
            }
            else
            {
                encoded += $"{(count > 1 ? count : "")}{currentChar}";
                count = 1;
            }

        }
        return encoded;
    }

    public static string Decode(string input)
    {
        string repeat = "", decoded = "";
        char currentChar;

        for (int i = 0; i < input.Length; i++)
        {
            currentChar = input[i];
            bool ok = Int32.TryParse(currentChar.ToString(), out int val);

            if (ok)
            {

                repeat += currentChar;
            }
            else
            {
                if (repeat == "")
                {
                    decoded += currentChar;
                }
                else
                {
                    decoded += $"{new string(currentChar, Int32.Parse(repeat))}";
                    repeat = "";
                }
            }
        }
        return decoded;
    }
}
