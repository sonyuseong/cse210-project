class ReflectionActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "How did you get started?",
        "What could you learn from this experience?"
    };

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void DoActivity(int duration)
    {
        Console.WriteLine($"\nPrompt: {_prompts[new Random().Next(_prompts.Count)]}");
        ShowSpinner(3);
        int timeSpent = 0;
        var rand = new Random();

        while (timeSpent < duration)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(5);
            timeSpent += 5;
        }
    }
}
