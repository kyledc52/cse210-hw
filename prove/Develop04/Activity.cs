using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

public class Activity
{
    private double _duration;
    private Stopwatch _stopWatch;
    private Random _random;
    private bool _isRunning;

    public Activity()
    {
        _stopWatch = new Stopwatch();
        _random = new Random();
        _isRunning = true;
    }

    protected void Pause(int seconds)
    {
        string[] displays = { "\\", "|", "/", "-" };
        if (_isRunning) {
            for (int i = 0; i < seconds * 4 && GetElapsedTime() < GetDuration(); i++)
            {
                int indexCalculation = i % displays.Length;
                Console.Write($"\b{displays[indexCalculation]}");
                Thread.Sleep(1000/4);
            }
        }
        else // post activity
        {
            for (int i = 0; i < seconds * 4; i++)
            {
                int indexCalculation = i % displays.Length;
                Console.Write($"\b{displays[indexCalculation]}");
                Thread.Sleep(1000/4);
            }
        }
    }

    public double GetDuration()
    {
        return _duration;
    }

    public void SetDuration(double dur)
    {
        _duration = dur;
    }

    public int GetUserDurationInput()
    {   
        int userDur = 0;

        while (true)
        {
            Console.Write("How long, in seconds, would you like your session to be?: ");
            try
            {
                userDur = int.Parse(Console.ReadLine().Trim());
                if (userDur <= 0)
                {
                    throw new FormatException();
                }

                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Not a valid duration. Try again.");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Not a valid duration. Try again.");
            }
        }
        Thread.Sleep(1000);
        return userDur;
    }

    public void StartStopWatch()
    {
        _stopWatch.Restart();
    }

    public void StopStopWatch()
    {
        _stopWatch.Stop();
    }

    public double GetElapsedTime()
    {
        return _stopWatch.Elapsed.TotalSeconds;
    }

    public void DisplayCountDowns(string message="", int howLong=3, string upOrDown="up")
    {
        if (upOrDown == "down")
        {
            for (int i = howLong; i > 0 && GetElapsedTime() < GetDuration(); i--)
            {
                Console.Write($"\r{message}{i}");
                Thread.Sleep(1000);
            }
        }
        else
        {
            for (int i = 1; i <= howLong && GetElapsedTime() < GetDuration(); i++)
                {
                    Console.Write($"\r{message}{i}");
                    Thread.Sleep(1000);
                }
        }
    }
        
    public void DisplayStartMessage()
    {
        if (GetType().Name == "BreathingActivity")
        {
            _isRunning = true;
            Console.Clear();

            Console.WriteLine("Welcome to the Breathing Activity");
            Console.WriteLine();
            Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        }
        else if (GetType().Name == "ReflectionActivity")
        {
            _isRunning = true;
            Console.Clear();

            Console.WriteLine("Welcome to the Reflection Activity");
            Console.WriteLine();
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        }
        else if (GetType().Name == "ListingActivity")
        {
            _isRunning = true;
            Console.Clear();

            Console.WriteLine("Welcome to the Listing Activity");
            Console.WriteLine();
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        }
    }

    public void DisplayStopMessage()
    {
        if (GetType().Name == "BreathingActivity")
        {
            _isRunning = false;
            Console.WriteLine("Well done!!!");
            Pause(4);
            Console.WriteLine($"\nYou have completed {GetDuration()} seconds of the Breathing Activity!");
            Pause(4);
            Console.Clear();
        }
        else if (GetType().Name == "ReflectionActivity")
        {
            _isRunning = false;
            Console.WriteLine("\nWell done!!!");
            Pause(4);
            Console.WriteLine($"\nYou have completed {GetDuration()} seconds of the Reflecting Activity!");
            Pause(4);
            Console.Clear();
        }
        else if (GetType().Name == "ListingActivity")
        {
            _isRunning = false;
            Console.WriteLine("\nWell done!!!");
            Pause(4);
            Console.WriteLine($"\nYou have completed {GetDuration()} seconds of the Listing Activity!");
            Pause(4);
            Console.Clear();
        }
    }

    public void DisplayGetReady()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        Pause(4);
        Console.Clear();
    }

    public string GetRandomPrompt(List<string> prompts)
    {
        return prompts[_random.Next(prompts.Count)];
    }
}