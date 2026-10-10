using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

class Program
{
    // access w/o creating object
    static bool running;

    static void Main(string[] args)
    {
        Journal userJournal = new Journal();
        running = true;

        while (running) {
            DisplayMenu(userJournal);
        }
    }

    static void DisplayMenu(Journal currentJournal)
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        
        string userOption = Console.ReadLine();

        // use journal class
        if (userOption == "1")
        {
            // Write
            // choose random prompt
            string prompt = currentJournal.GeneratePrompt();
            Console.WriteLine(prompt);

            // ask if they want a different prompt
            Console.Write("Would you like a different prompt? ");
            string difPrompt = Console.ReadLine();

            if (difPrompt.ToLower() == "yes")
            {
                prompt = currentJournal.GeneratePrompt();
                Console.WriteLine(prompt);
            }

            // create entry and add it
            string response = Console.ReadLine();
            currentJournal.AddEntry(response, prompt);
            // currentJournal.Display();
        }
        else if (userOption == "2")
        {
            // Display
            Console.WriteLine();
            currentJournal.Display();
        }
        else if (userOption == "3")
        {
            // Load
            Console.Write("What is the name of the saved file? ");
            string savedFileName = Console.ReadLine();
            currentJournal.LoadToFile(savedFileName);
        }
        else if (userOption == "4")
        {
            // Save
            Console.Write("What would you like to name the saved file? ");
            string nameOfFile = Console.ReadLine();

            currentJournal.SaveToFile(nameOfFile);
        }
        else if (userOption == "5")
        {
            // Quit
            running = false;
        }
        else
        {
            Console.WriteLine("Invalid Option.");
        }
    }
}