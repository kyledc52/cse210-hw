public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int pointsValue, bool isComplete = false) : base(name, desc, pointsValue, isComplete)
    {
    }

    public override void RecordEvent(GoalManager gm)
    {
        gm.AddPoints(GetPointsValue());
        Console.WriteLine($"You earned {GetPointsValue()} points!");
    }

    public override string GetSaveString()
    {
        return $"{GetType().Name}:{GetName()},{GetDescription()},{GetPointsValue()},{isCompleted()}";
    }

    public override void DisplayGoal()
    {
        string completedStrValue = GetCompletedStr();

        Console.WriteLine($"[{completedStrValue}] {GetName()} ({GetDescription()})");
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