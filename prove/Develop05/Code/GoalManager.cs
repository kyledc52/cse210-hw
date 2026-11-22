using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.IO.Enumeration;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Win32.SafeHandles;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private string[] _ranks = {"Novice", "Apprentice", "Adventurer", "Hero", "Legend"};

    private string _fileName;
    private string _path;
    private int _totalPoints;

    public GoalManager()
    {
        _fileName = "goalmanager";

        CreateFile();
    }

    public string GetRank()
    {
        if (GetTotalPoints() >= 5000)
        {
            return _ranks[4];
        }
        else if (GetTotalPoints() >= 2500)
        {
            return _ranks[3];
        }
        else if (GetTotalPoints() >= 1000)
        {
            return _ranks[2];
        }
        else if (GetTotalPoints() >= 500)
        {
            return _ranks[1];
        }
        else
        {
            return _ranks[1];
        }
    }

    public int GetNumberOfGoals()
    {
        return _goals.Count;
    }

    public void RecordEvent(int index)
    {
        _goals[index].RecordEvent(this);
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

    public void CreateGoal(int option, string name, string desc, int points, bool complete, int targetAmount, int bonusAmount)
    {
        switch (option)
        {
            case 1:
                // Simple Goal
                SimpleGoal simpleGoal = new SimpleGoal(name, desc, points);
                _goals.Add(simpleGoal);
                break;
            case 2:
                // Check List Goal
                CheckListGoal checkGoal = new CheckListGoal(name, desc, points, targetAmount, bonusAmount);
                _goals.Add(checkGoal);
                break;
            case 3:
                // Eternal Goal
                EternalGoal eternalGoal = new EternalGoal(name, desc, points);
                _goals.Add(eternalGoal);
                break;
            default:
                Console.WriteLine("Could not find specified goal type.");
                break;
        }
    }

    public void DisplayGoals()
    {
        foreach (Goal g in _goals)
        {
            g.DisplayGoal();
        }
    }

    // Create a file and save it to same file
    public void SaveToFile(string newFileName)
    {
        string newPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..", "..", "..",
            "Saves",
            newFileName + ".txt"
        );

        bool namedFile = NameFile(newFileName, newPath);
        
        if (namedFile)
        {
            WriteGoalsToFile();
        }
    }

    // Rename existing premade file to what user wants
    public bool NameFile(string newFileName, string newPath)
    {
        try
        {
            File.Move(_path, newPath);
        }
        catch (IOException)
        {
            Console.WriteLine("A file with that name already exists!");
            return false;
        }

        _path = newPath;
        return true;
    }

    // Used for LoadToFile()
    public (string, bool) GetLoadedPath(string fileName)
    {
        bool foundFile = false;

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
            return (_path, foundFile);
        }

        return (loadedPath, foundFile=true);
    }

    // Used for LoadToFile()
    // Convert from file to data structure
    public void ReadToFile(string fileName)
    {
        using (StreamReader sr = new StreamReader(_path))
        {
            // First line is the total amount of points
            _totalPoints = int.Parse(sr.ReadLine());
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                
                GoalData gData = new GoalData(line);
                
                switch (gData.ClassName)
                {
                    case ("SimpleGoal"):
                    SimpleGoal sGoal = new SimpleGoal(gData.GoalName, gData.GoalDescription, gData.PointsValue);
                    _goals.Add(sGoal);
                        break;
                    case ("CheckListGoal"):
                        CheckListGoal clGoal = new CheckListGoal(gData.GoalName, gData.GoalDescription, gData.PointsValue, gData.TargetAmount, gData.BonusPoints);
                        _goals.Add(clGoal);
                        break;
                    case ("EternalGoal"):
                        EternalGoal eGoal = new EternalGoal(gData.GoalName, gData.GoalDescription, gData.PointsValue);
                        _goals.Add(eGoal);
                        break;
                }
            }
        }
    }

    public void LoadToFile(string fileName)
    {
        _goals.Clear();

        var (loadedPath, foundFile) = GetLoadedPath(fileName);

        if (!foundFile)
        {
            return;
        }

        _path = loadedPath;

        ReadToFile(_path);
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

    public int GetTotalPoints()
    {
        return _totalPoints;
    }

    public void AddPoints(int points)
    {
        _totalPoints += points;
    }

    public void ListAllGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write(i+1+". ");
            _goals[i].DisplayGoal();
        }
    }
}