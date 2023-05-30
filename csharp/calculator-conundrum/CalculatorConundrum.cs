using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        try
        {
            int answer = 0;
            switch (operation)
            {
                case "+":
                    answer = operand1 + operand2;
                    break;
                case "*":
                    answer = operand1 * operand2;
                    break;
                case "/":
                    answer = operand1 / operand2;
                    break;
                case "":
                    throw new ArgumentException();
                case null:
                    throw new ArgumentNullException();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return $"{operand1} {operation} {operand2} = {answer}";
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
