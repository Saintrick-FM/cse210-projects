class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            string goalName = goal.Name;
            Console.WriteLine($"{count}. {goalName}");
            count++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetStringRepresentation()}");
            count++;
        }
    }

    public void CreateGoal(string name, string description, int points, GoalType type, int target = 0, int bonus = 0, bool isComplete = false, int _amountCompleted = 0)
    {
        switch (type)
        {
            case GoalType.SimpleGoal:
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
                break;
            case GoalType.EternalGoal:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case GoalType.ChecklistGoal:
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, _amountCompleted));
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }
    }

    public void RecordEvent(int goalId)
    {
        if (goalId >= 0 && goalId <= _goals.Count)
        {
            Goal currentGoal = _goals[goalId - 1];
            currentGoal.RecordEvent();
            _score += currentGoal.Points;

            if (currentGoal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.IsComplete() == true)
                {
                    _score += checklistGoal.Bonus;
                    Console.WriteLine($"\nCongratulations! You have earned {currentGoal.Points + checklistGoal.Bonus} points.");
                }
                else
                {
                    Console.WriteLine($"\nCongratulations! You have earned {currentGoal.Points} points.");
                }
            }
            Console.WriteLine($"You now have {_score} points.\n");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score}");
            foreach (var goal in _goals)
            {
                writer.WriteLine($"{goal.GetDetailsString()}");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {

            string[] lines = System.IO.File.ReadAllLines(filename);
            if (lines.Length > 1)
            {
                _score += int.Parse(lines[0]);
                for (int i = 1; i < lines.Length; i++)
                {
                    string goalChoosed = lines[i].Split(":")[0];
                    string[] parts = lines[i].Split(":")[1].Split(",");
                    string name = parts[0];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);

                    if (goalChoosed == "SimpleGoal")
                    {
                        if (parts[3] == "True")
                        {
                            CreateGoal(name, description, points, ConvertToGoalType("1"), 0, 0, true);
                        }
                        else
                        {
                            CreateGoal(name, description, points, ConvertToGoalType("1"), 0, 0, false);
                        }
                    }

                    if (goalChoosed == "EternalGoal")
                    {

                        CreateGoal(name, description, points, ConvertToGoalType("2"), 0, 0, false);
                    }

                    if (goalChoosed == "ChecklistGoal")
                    {
                        int bonus = int.Parse(parts[3]);
                        int target = int.Parse(parts[4]);
                        int amountCompleted = int.Parse(parts[5]);
                        CreateGoal(name, description, points, ConvertToGoalType("3"), target, bonus, false, amountCompleted);
                    }

                }

            }
            else
            {
                Console.WriteLine("No entry found");
            }

        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }

    public GoalType ConvertToGoalType(string typeChoice)
    {
        switch (typeChoice)
        {
            case "1":
                return GoalType.SimpleGoal;
            case "2":
                return GoalType.EternalGoal;
            case "3":
                return GoalType.ChecklistGoal;
            default:
                throw new ArgumentException("Invalid goal type choice.");
        }
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu options :");
            Console.WriteLine("  1. Create New Goal ");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        string goalChoosed = ChooseTypeOfGoal();
                        GoalCreation(goalChoosed);
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        Console.Write("What is the filename for the goal file? ");
                        string fileName = Console.ReadLine();
                        SaveGoals(fileName);
                        break;
                    case 4:
                        Console.Write("What is the filename for the goal file? ");
                        string input = Console.ReadLine();
                        LoadGoals(input);
                        break;
                    case 5:
                        ListGoalNames();
                        Console.Write("Which goal did you accomplish? ");
                        int userChoice = Convert.ToInt32(Console.ReadLine());
                        RecordEvent(userChoice);

                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"Invalid choice!");
                        break;
                }

            }
            catch (System.Exception)
            {
                Console.WriteLine($"Invalid choice!");
            }

        }
    }
    public string ChooseTypeOfGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        return typeChoice;
    }
    public void GoalCreation(string goalType)
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        int target = 0;
        int bonusPoints = 0;

        if (goalType == "3")
        {
            Console.Write("Enter target: ");
            target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            bonusPoints = int.Parse(Console.ReadLine());
            CreateGoal(name, description, points, ConvertToGoalType(goalType), target, bonusPoints);
        }
        else
        {
            CreateGoal(name, description, points, ConvertToGoalType(goalType));
        }


    }
}