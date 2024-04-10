class EternalGoal : Goal
{
    private GoalType _goalType;
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _goalType = GoalType.EternalGoal;
    }

    public override void RecordEvent()
    {
        // EternalGoal goals are always considered "completed" when recorded
        Console.WriteLine("EternalGoal goal recorded.");
    }

    public override bool IsComplete()
    {
        return false; // EternalGoal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_goalType}:{_shortName},{_description},{_points}";
    }

    public override string GetStringRepresentation()
    {
        return $"[ ] {_shortName} ({_description})";
    }
    // public string GoalType { get { return _goalType; } }
}