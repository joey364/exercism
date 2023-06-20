using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int count = 0;
        int num = number;

        if (num < 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        while (num > 1)
        {
            if (num % 2 == 0)
            {
                num = num / 2;
            }
            else
            {
                num = 3 * num + 1;
            }
            ++count;
        }
        return count;
    }
}
