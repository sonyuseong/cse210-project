// Base class
abstract class Activity
{
    protected string _name;
    protected string _description;

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}...\n{_description}\n");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        DoActivity(duration);
        End(duration);
    }

    protected void End(int duration)
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} activity for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
{
    string[] spinner = { "|", "/", "-", "\\" };
    DateTime endTime = DateTime.Now.AddSeconds(seconds);
    int i = 0;

    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[i % spinner.Length]);
        Thread.Sleep(200);
        Console.Write("\b \b");
        i++;
    }

    Console.WriteLine();
}

    public abstract void DoActivity(int duration);
}
