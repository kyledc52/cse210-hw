using System.Threading.Channels;

public abstract class Goal
{
    private int _pointsValue;
    private string _name;
    private string _description;
    private bool _completed;
    private int _targetAmount;

    public Goal(string name, string desc, int pointsValue, bool isComplete = false)
    {
        _name = name;
        _description = desc;
        _pointsValue = pointsValue;
        
        if (GetType().Name == "EternalGoal")
        {
            _completed = false;
        }
        else
        {
            _completed = isComplete;
        }
    }
    
    public int Points
    {
        get
        {
            return _pointsValue;
        }
    }

    public void SetPoints(int points)
    {
        _pointsValue = points;
    }
    
    public int GetPointsValue()
    {
        return _pointsValue;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetComplete()
    {
        _completed = true;
    }

    public bool isCompleted()
    {
        return _completed;
    }

    public abstract void DisplayGoal();
    
    public abstract void RecordEvent(GoalManager gm);

    public abstract string GetSaveString();
}