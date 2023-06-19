using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        char currentChar, lookahead;
        int count = 1;
        StringBuilder encoded = new();

        for (int i = 0; i < input.Length; i++)
        {
            currentChar = input[i];
            lookahead = i + 1 == input.Length ? '0' : input[i + 1];
            if (currentChar == lookahead)
            {
                count++;
            }
            else
            {
                encoded.Append($"{(count > 1 ? count : "")}{currentChar}");
                count = 1;
            }

        }
        return encoded.ToString();
    }

    public static string Decode(string input)
    {
        string repeat = "";
        char currentChar;
        StringBuilder decoded = new();

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
                    decoded.Append(currentChar);
                }
                else
                {
                    decoded.Append($"{new string(currentChar, Int32.Parse(repeat))}");
                    repeat = "";
                }
            }
        }
        return decoded.ToString();
    }
}
