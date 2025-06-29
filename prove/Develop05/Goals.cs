public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) {}
    public override int RecordEvent() => value;
    public override bool IsComplete() => false;
    public override string GetStatus() => $"[∞] {name}";
    public override string GetSaveString() => $"Eternal|{name}|{value}";
}

public class SimpleGoal : Goal
{
    private bool completed = false;
    public SimpleGoal(string name, int value) : base(name, value) {}
    public override int RecordEvent() { completed = true; return value; }
    public override bool IsComplete() => completed;
    public override string GetStatus() => $"[{(completed ? "X" : " ")}] {name}";
    public override string GetSaveString() => $"Simple|{name}|{value}|{completed}";
}

public class ChecklistGoal : Goal
{
    private int target;
    private int count;
    private int bonus;

    public ChecklistGoal(string name, int value, int target, int bonus) : base(name, value)
    {
        this.target = target;
        this.bonus = bonus;
        this.count = 0;
    }

    public override int RecordEvent()
    {
        count++;
        if (count == target) return value + bonus;
        return value;
    }

    public override bool IsComplete() => count >= target;
    public override string GetStatus() => $"[{(IsComplete() ? "X" : " ")}] {name} -- Completed {count}/{target}";
    public override string GetSaveString() => $"Checklist|{name}|{value}|{target}|{bonus}|{count}";
}