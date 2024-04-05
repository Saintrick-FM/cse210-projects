class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
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
        return $"{_name}: {_description} - {_points} points per completion, {_bonus} bonus points for {_target} completions";
    }

    public override string GetStringRepresentation()
    {
        return $"Completed {_amountCompleted}/{_target} times - {_name}";
    }
}