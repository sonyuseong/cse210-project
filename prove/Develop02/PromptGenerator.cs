
using System.Collections.Generic;



public class PromptGenerator {
    public List<string> promptText = new List<string>()
{
    "What was the highlight of your day and why?",
    "Describe something that challenged you today. How did you handle it?",
    "What is one thing you're grateful for today?",
    "If you could relive one moment from today, what would it be and why?",
    "Write about a person who made your day better.",
    "What is a goal you're working toward, and how did you take a step toward it today?",
    "Describe your current mood and what might be causing it.",
    "What did you learn about yourself today?",
    "If tomorrow were a fresh start, what would you do differently?",
    "Write about something small that made you smile today."
};

    public string RandomGenerator()
    {
        Random random = new Random();
        int index = random.Next(promptText.Count);
        return promptText[index];
    }

}