using System;
using System.Collections.Generic;

//To meet the exceed requirement, I added a "progress gauge" at the top of the menu list. This gauge has a maximum score of 1000 points, and it visually represents the user's progress using a mix of - and o characters. As the user completes goals and earns points, the gauge fills proportionally with o characters, helping to motivate the user by showing their achievement visually.




class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
    const int maxPoints = 1000;
    static void Main(string[] args)
    {
        while (true)
        {
            DisplayProgressBar();
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save\n5. Load\n6. Quit");
            Console.Write("Select: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordGoal(); break;
                case "4": SaveToFile(); break;
                case "5": LoadFromFile(); break;
                case "6": return;
                default: Console.WriteLine("Invalid"); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Choose Type: 1. Simple 2. Eternal 3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Goal name: "); string name = Console.ReadLine();
        Console.Write("Points: "); int value = int.Parse(Console.ReadLine());

        if (type == "1") goals.Add(new SimpleGoal(name, value));
        else if (type == "2") goals.Add(new EternalGoal(name, value));
        else if (type == "3")
        {
            Console.Write("Times to complete: "); int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: "); int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, value, target, bonus));
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
    }

    static void RecordGoal()
    {
        ListGoals();
        Console.Write("Which goal did you complete?: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
            score += goals[index].RecordEvent();
    }
    static void SaveToFile()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        SaveAndLoad.SaveGoals(filename, score, goals);
        Console.WriteLine("Goals saved successfully.");
    }
    static void LoadFromFile()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        var result = SaveAndLoad.LoadGoals(filename);
        score = result.Item1;
        goals = result.Item2;
        Console.WriteLine("Goals loaded successfully.");
    }
    static void DisplayProgressBar()
    {
        const int barLength = 50;
        double ratio = Math.Min(1.0, (double)score / maxPoints);
        int filledLength = (int)(ratio * barLength);
        string bar = new string('o', filledLength) + new string('-', barLength - filledLength);
        Console.WriteLine($"[{bar}] *{maxPoints} points*");
    }
}