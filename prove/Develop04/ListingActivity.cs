public class ListingActivity : Activity
{
    private List<string> _listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private int _numOfItemsEntered = 0;

    public ListingActivity()
    {
    }
    
    public void start()
    {
        DisplayStartMessage();

        SetDuration(GetUserDurationInput());

        DisplayGetReady();

        string randPrompt = GetRandomPrompt(_listingPrompts);

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {randPrompt} ---\n");
        DisplayCountDowns("You may begin in: ", 5, "down");

        startListing();
        DisplayAmountOfItemsEntered();

        DisplayStopMessage();
    }

    public void startListing()
    {
        Console.WriteLine();
        StartStopWatch();
        
        while (GetElapsedTime() < GetDuration())
        {
            if (Console.KeyAvailable)
            {
                Console.Write("> ");
                Console.ReadLine();
                _numOfItemsEntered++;
            }
        }

        StopStopWatch();
    }

    public void DisplayAmountOfItemsEntered()
    {
        Console.WriteLine($"You listed {_numOfItemsEntered} items!");
    }
}