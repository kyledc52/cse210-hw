using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Whats is your first name?");
        String firstName = Console.ReadLine();
        Console.WriteLine("Whats is your last name?");
        String lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}