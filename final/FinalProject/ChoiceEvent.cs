using System;

class ChoiceEvent {
    private string description;
    private string statToIncrease;

    public ChoiceEvent(string desc, string stat) {
        description = desc;
        statToIncrease = stat;
    }

    public void Show(Player player) {
        TextAnimator.Show(description);
        Console.Write("Choose (Y/N): ");
        string input = Console.ReadLine();
        if (input?.ToUpper() == "Y") {
            player.GetStats().Increase(statToIncrease);
            Console.WriteLine($"{statToIncrease} increased!");
        } else {
            Console.WriteLine("You skipped the event.");
        }
    }
}
