public class ReflectionActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<String> _reflectQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
    }

    public void start()
    {
        DisplayStartMessage();

        string randPrompt = GetRandomPrompt(_reflectionPrompts);

        SetDuration(GetUserDurationInput());

        DisplayGetReady();

        Console.WriteLine("Consider the following\n");
        Console.WriteLine($"--- {randPrompt} ---\n"); 
        Console.Write("Press enter when you have something in mind:");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        DisplayCountDowns("You may begin in: ", 3, "down");
        
        startReflection();

        DisplayStopMessage();
    } 

    private void startReflection()
    {
        Console.Clear();
        StartStopWatch();
        
        // Create dictionary to compare with what questions we have used.
        Dictionary<int,bool> numsUsed = CreateQuestionDictionary();

        bool allUsed = false;
        while (GetElapsedTime() < GetDuration() && allUsed == false)
        {  
            // Check to see if all questions have been used
            allUsed = AllQuestionsUsed(numsUsed);
            if (allUsed)
            {
                break;
            }

            int indexOfQuestion = GetUnusedQuestionIndex(numsUsed);
            string randQuestion = _reflectQuestions[indexOfQuestion];

            DisplayQuestion(randQuestion);
        }

        StopStopWatch();
    }

    private void DisplayQuestion(string question)
    {
        Console.Write(question + "  ");
        Pause(8);
        Console.WriteLine();
    }
    
    private int GetUnusedQuestionIndex(Dictionary<int, bool> numsUsed)
    {
        bool gotGoodIndex = false;
        int indexOfQuestion = 0;

        while (!gotGoodIndex)
        {
            string randQuestion = GetRandomPrompt(_reflectQuestions);
            indexOfQuestion = _reflectQuestions.IndexOf(randQuestion);

            if (numsUsed[indexOfQuestion] == false)
            {
                gotGoodIndex = true;
                numsUsed[indexOfQuestion] = true;
            }
        }

        return indexOfQuestion;
    }

    private Dictionary<int, bool> CreateQuestionDictionary()
    {
        Dictionary<int, bool> createdDictionary = new Dictionary<int, bool>();
        for (int i = 0; i < _reflectQuestions.Count; i++)
        {
            createdDictionary.Add(i, false);
        }

        return createdDictionary;
    }

    private bool AllQuestionsUsed(Dictionary<int,bool> numsUsed)
    {
        bool allUsed = true;
        foreach (bool value in numsUsed.Values)
        {
            // if even 1 value is false, then return false
            if (value == false)
            {
                allUsed = false;
                break;
            }
        }
        
        return allUsed;
    }
}