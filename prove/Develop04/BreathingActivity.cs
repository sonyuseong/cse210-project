class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void DoActivity(int duration)
    {
        int cycleTime = 6;
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("\nBreathe in...");
            AnimatedBreath(inhale: true);
            Console.WriteLine("\nBreathe out...");
            AnimatedBreath(inhale: false);
        }
    }

    private void AnimatedBreath(bool inhale)
    {
        int totalSteps = 10;
        int totalDuration = 3000;
        int baseDelay = totalDuration / ((totalSteps * (totalSteps + 1)) / 2);

        for (int i = 1; i <= totalSteps; i++)
        {
            int delay = baseDelay * i;
            Console.WriteLine(new string('*', inhale ? i : (totalSteps - i + 1)));
            Thread.Sleep(delay);
        }
    }
}
