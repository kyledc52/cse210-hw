using System;

// For going above and beyond, I made a dictionary that detects which reflection questions are used and not used so they don't repeat eachother.
// I also used try and catch to detect if the user entered a valid number. I also used a bunch of helper methods to prevent 
// long code in 1 method. 
class Program
{
    static void Main(string[] args)
    {
        BreathingActivity bActivity = new BreathingActivity();
        ReflectionActivity rActivity = new ReflectionActivity();
        ListingActivity lActivity = new ListingActivity();

        while (true) 
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine("\t1. Breathing Activity");
            Console.WriteLine("\t2. Reflection Activity");
            Console.WriteLine("\t3. Listing Activity");
            Console.WriteLine("\t4. Quit");

            // make sure user input is valid
            int userInput;
            while (true)
            {
                Console.Write("Select a choice from the menu (1-4): ");
                try
                {
                    userInput = int.Parse(Console.ReadLine().Trim());
                    if (userInput > 0 && userInput <= 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Option.");
                }
            }


            // Begin activities
            switch (userInput)
            {
                case 1:
                    bActivity.start();
                    break;
                
                case 2:
                    rActivity.start();
                    break;
                
                case 3:
                    lActivity.start();
                    break;
                
                case 4:
                    return;
            }
        }
    }
}