class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
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
        return $"{_name}: {_description} - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"[{(_isComplete ? 'X' : ' ')}] {_name}";
    }
}