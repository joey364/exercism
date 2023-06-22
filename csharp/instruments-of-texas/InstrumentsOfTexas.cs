using System;

public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    {
        Operand1 = operand1;
        Operand2 = operand2;
        Inner = inner;
        Message = message;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
    public Exception Inner { get; }
    public override string Message { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {

        try
        {
            Multiply(x, y);
            return "Multiply succeeded";
        }
        catch (CalculationException cex) when (cex.Operand1 < 0 && cex.Operand2 < 0)
        {
            return $"Multiply failed for negative operands. {cex.Inner.Message}";
        }
        catch (CalculationException cex)
        {
            return $"Multiply failed for mixed or positive operands. {cex.Inner.Message}";
        }
    }

    public void Multiply(int x, int y)
    {
        try
        {
            calculator.Multiply(x, y);
        }
        catch (OverflowException overflowException)
        {
            throw new CalculationException(x, y, "Overflow exception", overflowException);
        }
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
