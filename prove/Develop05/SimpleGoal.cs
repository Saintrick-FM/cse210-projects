class SimpleGoal : Goal
{
    private bool _isComplete;
    private GoalType _goalType;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
        _goalType = GoalType.SimpleGoal;
    }
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
        _goalType = GoalType.SimpleGoal;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_goalType}:{_shortName},{_description},{_points},{_isComplete}";
    }

    public override string GetStringRepresentation()
    {
        return $"[{(_isComplete ? 'X' : ' ')}] {_shortName} ({_description})";
    }

}