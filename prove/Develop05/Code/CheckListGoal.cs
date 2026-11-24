public class CheckListGoal : Goal
{
    private int _amountCompleted = 0;
    private int _targetAmount;
    private int _bonusPoints;

    public CheckListGoal(string name, string desc, int points, int targetAmount, int bonusPoints, bool completed = false) : base (name, desc, points, completed)
    {
        _targetAmount = targetAmount;
        _bonusPoints = bonusPoints;
    }

    public override string GetSaveString()
    {
        return $"{GetType().Name}:{GetName()},{GetDescription()},{GetPointsValue()},{isCompleted()},{_amountCompleted},{_targetAmount},{_bonusPoints}";
    }

    public override void RecordEvent(GoalManager gm)
    {
        if (isCompleted())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }
        
        _amountCompleted++;
        gm.AddPoints(GetPointsValue());
        Console.WriteLine($"You earned {GetPointsValue()} points!");
        if (_amountCompleted >= _targetAmount)
        {
            SetComplete();
            gm.AddPoints(_bonusPoints);
            Console.WriteLine($"You earned {_bonusPoints} bonus points!");
        }
    }

    public override void DisplayGoal()
    {
        string completedStrValue = GetCompletedStr();

        Console.WriteLine($"[{completedStrValue}] {GetName()} ({GetDescription()}) -- amount completed {_amountCompleted} / {_targetAmount}");
    }

    private string GetCompletedStr()
    { 
        if (isCompleted())
        {
            return "X";
        }

        return " ";
    }
}