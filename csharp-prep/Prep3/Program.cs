using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number: ");
        String magicNumberUser = Console.ReadLine();
        int magicNumber = int.Parse(magicNumberUser);

        // Loop til they guess magic number
        String response;
        do
        {
            Console.WriteLine("What is your guess?: ");
            response = Console.ReadLine();
            if (int.Parse(response) < magicNumber)
            {
                Console.WriteLine("Higher!");
            }
            else if (int.Parse(response) > magicNumber)
            {
                Console.WriteLine("Lower!");
            }
        }   while (int.Parse(response) != magicNumber);

        Console.WriteLine("You guessed it!");
    }
}