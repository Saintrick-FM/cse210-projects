enum GoalType
{
    SimpleGoal,
    EternalGoal,
    ChecklistGoal
}

abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;


    public string Name { get { return _shortName; } }
    public int Points { get { return _points; } }
    public string Description { get { return _description; } }


    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }


    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
