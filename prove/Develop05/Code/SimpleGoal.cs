public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string desc, int pointsValue, bool isComplete = false) : base(name, desc, pointsValue, isComplete)
    {
    }

    // Reward points if goal is complete
    public override void RecordEvent(GoalManager gm)
    {
        if (!isCompleted())
        {
            SetComplete();

            gm.AddPoints(GetPointsValue());

            Console.WriteLine($"You earned {GetPointsValue()} points!");
        }
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