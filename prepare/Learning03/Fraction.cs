using System.Data.Common;
using System.Numerics;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
    }

    public Fraction(int t)
    {
        _top = t;
        _bottom = 1;
    }
    public Fraction(int t, int b)
    {
        _top = t;
        _bottom = b;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int t)
    {
        _top = t;
    } 

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int b)
    {
        _bottom = b;
    }

    public string GetFractionString()
    {
        string fracString = _top + "/" + _bottom;
        return fracString;
    }

    public double GetDecimalValue()
    {
        return Math.Round((double) _top / _bottom, 2);
    }
}