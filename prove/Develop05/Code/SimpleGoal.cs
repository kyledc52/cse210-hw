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
        }
    }
    
    public override string GetSaveString()
    {
        return $"{GetType().Name}:{GetName()},{GetDescription()},{GetPointsValue()},{isCompleted()}";
    }
}