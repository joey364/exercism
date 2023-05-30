using System;

class WeighingMachine
{
    private double weight = 0;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }

    public double Weight
    {
        get
        {
            return weight;
        }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;


    public string DisplayWeight
    {
        get
        {
            return $"{Math.Round(Weight - TareAdjustment, Precision).ToString($"F{Precision}")} kg";
        }
    }
}
