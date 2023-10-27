using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return self.amount == other.amount;
    }

    public static bool operator !=(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return self.amount != other.amount;
    }

    public static bool operator >(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return self.amount > other.amount;
    }

    public static bool operator <(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return self.amount < other.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return new CurrencyAmount(amount: self.amount + other.amount, currency: self.currency);
    }


    public static CurrencyAmount operator -(CurrencyAmount self, CurrencyAmount other)
    {
        if (self.currency != other.currency) throw new ArgumentException();
        return new CurrencyAmount(amount: self.amount - other.amount, currency: self.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount self, decimal multiplier)
    {
        return new CurrencyAmount(amount: self.amount * multiplier, currency: self.currency);
    }

    public static CurrencyAmount operator *(decimal multiplier, CurrencyAmount self)
    {
        return new CurrencyAmount(amount: self.amount * multiplier, currency: self.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount self, decimal divisor)
    {
        return new CurrencyAmount(self.amount / divisor, self.currency);
    }

    public static explicit operator double(CurrencyAmount self)
    {
        return (double)self.amount;
    }

    public static implicit operator decimal(CurrencyAmount self)
    {
        return self.amount;
    }
}
