class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    private GoalType _goalType;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _goalType = GoalType.ChecklistGoal;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {

        return $"{_goalType}:{_shortName}, {_description}, {_points}, {_bonus}, {_target}, {_amountCompleted}";
    }

    public override string GetStringRepresentation()
    {
        return $"[{(IsComplete() ? 'X' : ' ')}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
}