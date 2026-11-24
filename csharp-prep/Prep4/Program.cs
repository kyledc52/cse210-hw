using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        String n;
        List<int> numbers = new List<int>();

        // get list
        while(true)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            n = Console.ReadLine();
            if (int.Parse(n) == 0)
            {
                break;
            }
            else
            {
                // add to list
                numbers.Add(int.Parse(n));
            }
        }

        // get sum
        int sum = 0;
        for (int i = 0; i < numbers.Count(); i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"Sum: {sum}.");

        // get average 
        double average = (double)sum / numbers.Count();
        Console.WriteLine($"The average is {average}.");

        // get largest number
        int largestNumber = numbers.Max();
        Console.WriteLine($"The largest number is {largestNumber}.");
    }
}