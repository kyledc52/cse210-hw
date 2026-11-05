using System.Runtime.InteropServices.Marshalling;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
    }

    public void start()
    {
        DisplayStartMessage();
        SetDuration(GetUserDurationInput());

        DisplayGetReady();
        
        startBreathing();
        
        DisplayStopMessage();
    }

    private void startBreathing()
    {
        StartStopWatch();

        while (GetElapsedTime() < GetDuration())
        {
            DisplayCountDowns("Breath in...", 4);
            Console.WriteLine();

            DisplayCountDowns("Breath out...", 4);

            if (GetElapsedTime() < GetDuration())
            {
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        
        StopStopWatch();
    }
}