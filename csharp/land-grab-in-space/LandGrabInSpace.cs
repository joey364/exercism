using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        TLeft = c1;
        TRight = c2;
        BLeft = c3;
        BRight = c4;
    }

    public Coord TLeft { get; }
    public Coord TRight { get; }
    public Coord BLeft { get; }
    public Coord BRight { get; }

    public ushort GetLongestSide()
    {
        return (ushort)Math.Max(TLeft.X - TRight.X, Math.Max(BLeft.X - BRight.X, Math.Max(BRight.Y - TRight.Y, BLeft.Y - TLeft.Y)));
    }
}


public class ClaimsHandler
{
    private HashSet<Plot> _registeredPlots = new();
    private Plot _lastRegisteredPlot = new();

    public void StakeClaim(Plot plot)
    {
        _registeredPlots.Add(plot);
        _lastRegisteredPlot = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _registeredPlots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return Equals(_lastRegisteredPlot, plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longest = new Plot();
        foreach (Plot plot in _registeredPlots)
        {
            if (plot.GetLongestSide() > longest.GetLongestSide())
            {
                longest = plot;
            }
        }

        return longest;
    }
}
