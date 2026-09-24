using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static String PromptUserName()
    {
        Console.WriteLine("What's your name?: ");
        String name = Console.ReadLine();
        return name;

    }

    static int PromptUserNumber()
    {
        Console.WriteLine("What's your favoite number?: ");
        String number = Console.ReadLine();
        return int.Parse(number);
    } 

    static int PromtUserBirthYear(out int birthyear)
    {
        Console.WriteLine("What's your birth year?: ");
        String year = Console.ReadLine();
        birthyear = int.Parse(year);
        return birthyear;
    }

    static int SquareNumber(int n)
    {
        return n*n;
    }

    static void DisplayResult(String name, int birthyear, int squaredNumber)
    {
        int ageTurningNumber = 2026 - birthyear;
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        Console.WriteLine($"{name}, you will turn {ageTurningNumber} this year.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        String name = PromptUserName();
        int num = PromptUserNumber();
        int year = PromtUserBirthYear(out year);
        int sqNum = SquareNumber(2);
        DisplayResult(name, year, sqNum);
    }
}