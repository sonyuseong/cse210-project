public abstract class Goal
{
    protected string name;
    protected int value;
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string GetSaveString();
    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }
}