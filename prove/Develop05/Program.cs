using System;
using System.Collections.Generic;
using System.IO;
// using Newtonsoft.Json;

using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();

        // Load saved goals if any
        manager.LoadGoals();

        // Sample usage
        manager.CreateGoal("Read Scriptures", "Read scriptures daily", 100, GoalType.Eternal);
        manager.CreateGoal("Run Marathon", "Complete a marathon", 1000, GoalType.Simple);
        manager.CreateGoal("Attend Temple", "Attend the temple", 50, GoalType.Checklist, 10, 500);

        manager.ListGoalNames();

        manager.RecordEvent("Read Scriptures");
        manager.RecordEvent("Attend Temple");
        manager.RecordEvent("Run Marathon");
        manager.RecordEvent("Attend Temple");
        manager.RecordEvent("Attend Temple");
        manager.RecordEvent("Attend Temple");

        manager.ListGoalDetails();
        manager.DisplayPlayerInfo();

        // Save goals before exiting
        manager.SaveGoals();
    }
}