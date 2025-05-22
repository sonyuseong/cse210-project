using System;

class Program
{
    static void Main(string[] args)
    {
        
        Fraction case1 = new Fraction();
        Console.WriteLine(case1.GetFractionString());
        Console.WriteLine(case1.GetDecimalValue());

        Fraction case2 = new Fraction(5);
        Console.WriteLine(case2.GetFractionString());
        Console.WriteLine(case2.GetDecimalValue());

        Fraction case3 = new Fraction(3,4);
        Console.WriteLine(case3.GetFractionString());
        Console.WriteLine(case3.GetDecimalValue());

        Fraction case4 = new Fraction(1,3);
        Console.WriteLine(case4.GetFractionString());
        Console.WriteLine(case4.GetDecimalValue());
    }
}