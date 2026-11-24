using System.Runtime.CompilerServices;

public class GoalData
{
    private string _className;
    private string _goalName;
    private string _goalDesc;
    private int _pointsValue;
    private bool _completed;
    private int _amountCompleted = 0;
    private int _targetAmount;
    private int _bonusPoints;

    public GoalData(string strToParse)
    {
        string[] sub = strToParse.Split(":");
        string[] parts = sub[1].Split(",");
        
        _className = sub[0];
        _goalName = parts[0];
        _goalDesc = parts[1];
        _pointsValue = int.Parse(parts[2]);
        _completed = bool.Parse(parts[3]);

        if (parts.Length == 7)
        {
            _amountCompleted = int.Parse(parts[4]);
            _targetAmount = int.Parse(parts[5]);
            _bonusPoints = int.Parse(parts[6]);
        }
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTargetAmount()
    {
        return _targetAmount;
    }

    public string GetClassName()
    {
        return _className;
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public string GetGoalDescription()
    {
        return _goalDesc;
    }

    public int GetPointsValue()
    {
        return _pointsValue;
    }

    public bool GetIsCompleted()
    {
        return _completed;
    }
}