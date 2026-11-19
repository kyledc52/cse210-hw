using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.IO.Enumeration;
using Microsoft.Win32.SafeHandles;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private string _fileName;
    private string _path;
    private int _totalPoints;


    public GoalManager()
    {
        _fileName = "goalmanager";

        CreateFile();
    }

    public void CreateFile()
    {
        string directory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..", "..", "..",
            "Saves"
        );

        Directory.CreateDirectory(directory);

        _path = Path.Combine(directory, _fileName + ".txt");

        if (!File.Exists(_path))
        {
            File.CreateText(_path).Close();
        }
    }

    public void CreateGoal(int option, string name, string desc, int points, bool complete = false)
    {
        switch (option)
        {
            case 1:
                // Simple Goal
                SimpleGoal simpleGoal = new SimpleGoal(name, desc, points, complete);
                _goals.Add(simpleGoal);
                Console.WriteLine(_goals.Count);
                break;
            // case 2:
            //     // Check List Goal
            //     CheckListGoal checkGoal = new CheckListGoal(name, desc);
            //     _goals.Add(checkGoal);
            //     break;
            // case 3:
            //     // Eternal Goal
            //     EternalGoal eternalGoal = new EternalGoal(name, desc);
            //     _goals.Add(eternalGoal);
            //     break;
            // default:
            //     Console.WriteLine("Could not find specified goal type.");
            //     break;
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal g in _goals)
        {
            g.DisplayGoal();
        }
    }

    // Create a file and save it to that
    public void SaveToFile(string newFileName)
    {
        string newPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..", "..", "..",
            "Saves",
            newFileName + ".txt"
        );

        // Rename file to what the user wants
        try
        {
            File.Move(_path, newPath);
        }
        catch (IOException)
        {
            Console.WriteLine("A file with that name already exists!");
            return;
        }
        _path = newPath;

        WriteGoalsToFile();
    }

    public void LoadToFile(string fileName)
    {
        // Find the file
        string loadedPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..", "..", "..",
            "Saves",
            fileName + ".txt"
        );
        
        if (!File.Exists(loadedPath))
        {
            Console.WriteLine($"Could not find file with name of \"{fileName}\".");
            return;
        }

        _path = loadedPath;

        using (StreamReader sr = new StreamReader(_path))
        {
            _totalPoints = int.Parse(sr.ReadLine());
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                
                GoalData gData = new GoalData(line);
                
                switch (gData.ClassName)
                {
                    case ("SimpleGoal"):
                    SimpleGoal sGoal = new SimpleGoal(gData.ClassName, gData.GoalDescription, gData.PointsValue, gData.Completed);
                    _goals.Add(sGoal);
                        break;
                    case ("CheckListGoal"):
                        break;
                    case ("EternalGoal"):
                        break;
                }
            }
        }
    }

    public void WriteGoalsToFile()
    {
        // Clear file to update
        File.WriteAllText(_path, "");

        using (StreamWriter sw = new StreamWriter(_path, true))
        {
            sw.WriteLine(_totalPoints);
            foreach (Goal g in _goals)
            {
                string line = g.GetSaveString();
                sw.WriteLine(line);
            } 
        }
    }

    public void AddPoints(int points)
    {
        _totalPoints += points;
    }
}