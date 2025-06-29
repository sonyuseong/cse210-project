using System;
using System.Collections.Generic;
using System.IO;

public static class SaveAndLoad
{
    public static void SaveGoals(string filename, int score, List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.GetSaveString());
            }
        }
    }

    public static (int, List<Goal>) LoadGoals(string filename)
    {
        int score = 0;
        List<Goal> goals = new List<Goal>();

        if (!File.Exists(filename)) return (score, goals);

        string[] lines = File.ReadAllLines(filename);
        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "Simple":
                    var simple = new SimpleGoal(parts[1], int.Parse(parts[2]));
                    if (bool.Parse(parts[3])) simple.RecordEvent();
                    goals.Add(simple);
                    break;
                case "Eternal":
                    goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                    break;
                case "Checklist":
                    var checklist = new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]));
                    int count = int.Parse(parts[5]);
                    for (int j = 0; j < count; j++) checklist.RecordEvent();
                    goals.Add(checklist);
                    break;
            }
        }
        return (score, goals);
    }
}