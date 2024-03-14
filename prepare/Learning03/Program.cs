using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"{fraction1.getFractionString()}");
        Console.WriteLine($"{fraction1.getDecimalValue()}");

        Console.WriteLine($"{fraction2.getFractionString()}");
        Console.WriteLine($"{fraction2.getDecimalValue()}");

        Console.WriteLine($"{fraction3.getFractionString()}");
        Console.WriteLine($"{fraction3.getDecimalValue()}");

        Console.WriteLine($"{fraction4.getFractionString()}");
        Console.WriteLine($"{fraction4.getDecimalValue()}");
    }
}
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    // Getters and setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public int GetBottom()
    {
        return _bottom;
    }
    public double getDecimalValue()
    {
        return (double)_top / _bottom;
    }
    public string getFractionString()
    {
        string result = _top + "/" + _bottom;
        return result;
    }
}