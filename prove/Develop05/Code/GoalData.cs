using System.Runtime.CompilerServices;

public class GoalData
{
    private string _className;
    private string _goalName;
    private string _goalDesc;
    private int _pointsValue;
    private bool _completed;

    public GoalData(string strToParse)
    {
        Console.WriteLine("str: " + strToParse);

        string[] sub = strToParse.Split(":");
        string[] parts = sub[1].Split(",");
        
        _className = sub[0];
        _goalName = parts[0];
        _goalDesc = parts[1];
        _pointsValue = int.Parse(parts[2]);

        if (parts.Length > 3)
        {
            _completed = bool.Parse(parts[3]);
        }
    }

    // Properties
    public string ClassName
    {
        get
        {
            return _className;
        }
    }

    public string GoalName
    {
        get
        {
            return _goalName;
        }
    }

    public string GoalDescription
    {
        get
        {
            return _goalDesc;
        }
    }

    public int PointsValue
    {
        get
        {
            return _pointsValue;
        }
    }

    public bool Completed
    {
        get
        {
            return _completed;
        }
    }
}