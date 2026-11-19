using System;

class Program
{
    static GoalManager gm = new GoalManager();

    static void Main(string[] args)
    {

        while (true)
        {
            int option = DisplayMenuOptionInput();
            
            switch (option)
            {
                case 1:
                    // Create a New Goal
                    CreateNewGoal();
                    break;

                case 2:
                    // List Goals
                    ListGoals();
                    break;

                case 3:
                    // Save File
                    SaveFile();
                    break;

                case 4:
                    // Load File
                    LoadFile();
                    break;

                case 5:
                    // Record Event
                    RecordEvent();
                    break;

                case 6:
                    // Quit
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public static void RecordEvent()
    {
        
    }

    public static void LoadFile()
    {
        Console.Write("What file name would you like to load?: ");
        gm.LoadToFile(Console.ReadLine());
    }

    public static void SaveFile()
    {
        Console.Write("What would you like to name your file?: ");
        gm.SaveToFile(Console.ReadLine());
    } 

    public static void ListGoals()
    {
        
    }

    public static void CreateNewGoal()
    {
        int goalOption = DisplayGoalMenuInput();
        var (goalName, goalDesc, goalPoints) = GetUserGoalDetails();

        gm.CreateGoal(goalOption, goalName, goalDesc, goalPoints);
    }

    // returns tuple
    public static (string, string, int) GetUserGoalDetails() 
    {
        Console.Write("What's the name of your goal?: ");
        string goalName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("What's the description of your goal?: ");
        string goalDesc = Console.ReadLine();
  
        int goalPoints = GetNumberInRange("How many points will your goal offer?: ", 1, 10000);
        
        return (goalName, goalDesc, goalPoints);
    }

    public static int DisplayGoalMenuInput()
    {
        Console.WriteLine("What type of Goal would you like to make?");
        Console.WriteLine("1: Simple Goal");
        Console.WriteLine("2: CheckList Goal");
        Console.WriteLine("3: Eternal Goal");

        int userResponse = GetNumberInRange("Select an option (1-3): ", 1, 3);

        return userResponse;
    }

    public static int DisplayMenuOptionInput()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome To Eternal Quest");
        Console.WriteLine("1: Create New Goal");
        Console.WriteLine("2: List Goals");
        Console.WriteLine("3: Save Goals");
        Console.WriteLine("4: Load Goals");
        Console.WriteLine("5: Mark Goal Complete");
        Console.WriteLine("6: Quit");

        int userResponse = GetNumberInRange("Select an option (1-6): ", 1, 6);

        return userResponse;
    }

    public static int GetNumberInRange(string prompt, int min, int max)
    {
        int num;

        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
        {
            Console.WriteLine("Invalid Response");
            Console.Write(prompt);
        }

        return num;
    }
}