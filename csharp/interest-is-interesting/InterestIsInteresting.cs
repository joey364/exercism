using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float rate = -1f;
        if (balance < 0)
            rate = 3.213f;
        else if (balance >= 0 && balance < 1000)
            rate = 0.5f;
        else if (balance >= 1000 && balance < 5000)
            rate = 1.621f;
        else if (balance >= 5000)
            rate = 2.475f;
        return rate;
    }

    public static decimal Interest(decimal balance)
    {
        var rate = InterestRate(balance);
        return (Convert.ToDecimal(rate) / 100) * balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        var interest = Interest(balance);
        return interest + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var years = 0;
        do
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        } while (balance < targetBalance);
        return years;
    }
}
