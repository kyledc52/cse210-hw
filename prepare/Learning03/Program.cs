using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Fraction f = new Fraction();

        for (int i = 1; i <= 20; i++)
        {
            int randNumTop = random.Next(1,101);
            int randNumBottom = random.Next(1,101);

            f.SetTop(randNumTop);
            f.SetBottom(randNumBottom);

            Console.WriteLine($"Fraction: {i} string: {f.GetFractionString()} decimal: {f.GetDecimalValue()}");
        }
    }
}