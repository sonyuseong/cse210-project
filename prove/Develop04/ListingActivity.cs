class ListingActivity : Activity
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?",
        "When have you felt the Holy Ghost this month?"
    };

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    public override void DoActivity(int duration)
    {
        Console.WriteLine($"\nPrompt: {_prompts[new Random().Next(_prompts.Count)]}");
        Console.WriteLine("You will have a few seconds to think...");
        ShowSpinner(5);
        Console.WriteLine("Start listing items! (press Enter for each)");
        
        int itemCount = 0;
        var startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine();
                itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {itemCount} items!");
    }
}
