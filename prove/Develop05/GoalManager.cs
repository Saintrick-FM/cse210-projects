class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void Start()
    {
        Console.WriteLine("Eternal Quest Started");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.Name);
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(string name, string description, int points, GoalType type, int target = 0, int bonus = 0)
    {
        switch (type)
        {
            case GoalType.Simple:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case GoalType.Eternal:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case GoalType.Checklist:
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }
    }

    public void RecordEvent(string goalName)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            score += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals()
    {
        // string json = Newtonsoft.Json.JsonConvert.SerializeObject(goals);
        // File.WriteAllText("goals.json", json);
        // Console.WriteLine("Goals saved to file.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            // goals = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Goal>>(json);
            Console.WriteLine("Goals loaded from file.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}