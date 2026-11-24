using System;

// To go above and beyong, I learned how paths work in C# and I added a rank system to tell the user what rank they are. The ranks
// go up depending on how many points the user has.
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
                    gm.ListAllGoals();
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

    public static void CreateNewGoal()
    {
        int goalOption = DisplayGoalMenuInput();
        var (goalName, goalDesc, goalPoints) = GetUserGoalDetails();

        int targetAmount = 0;
        int bonusPoints = 0;

        if (goalOption == 2)
        {
            targetAmount = GetNumberInRange("How many times do you want to complete this goal?: ", 1, 1000);
            bonusPoints = GetNumberInRange("How many bonus points do you get at the end?: ", 1, 10000);
        }

        gm.CreateGoal(goalOption, goalName, goalDesc, goalPoints, false, targetAmount, bonusPoints);
    }

    public static void RecordEvent()
    {
        gm.ListAllGoals();
        
        string rankBefore = gm.GetRank();

        int goalOption = GetNumberInRange($"Which goal would you like to mark as completed (1-{gm.GetNumberOfGoals()})?: ", 1, gm.GetNumberOfGoals());

        gm.RecordEvent(goalOption-1);

        string rankAfter = gm.GetRank();

        if (rankBefore != rankAfter)
        {
            Console.WriteLine($"You ranked up!! You are now ranked: {rankAfter}");
        }
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

    // returns tuple
    public static (string, string, int) GetUserGoalDetails() 
    {
        Console.Write("What's the name of your goal?: ");
        string goalName = Console.ReadLine();
        Console.Write("What's the description of your goal?: ");
        string goalDesc = Console.ReadLine();
  
        int goalPoints = GetNumberInRange("How many points will your goal offer?: ", 1, 10000);
        
        return (goalName, goalDesc, goalPoints);
    }

    public static int DisplayGoalMenuInput()
    {
        Console.WriteLine("What type of Goal would you like to create?");
        Console.WriteLine("1: Simple Goal");
        Console.WriteLine("2: CheckList Goal");
        Console.WriteLine("3: Eternal Goal");

        int userResponse = GetNumberInRange("Select an option (1-3): ", 1, 3);

        return userResponse;
    }

    public static int DisplayMenuOptionInput()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {gm.GetTotalPoints()} points. Rank: {gm.GetRank()}");
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