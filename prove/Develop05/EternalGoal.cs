class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are always considered "completed" when recorded
        Console.WriteLine("Eternal goal recorded.");
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_name}: {_description} - {_points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"[ ] {_name}";
    }
}