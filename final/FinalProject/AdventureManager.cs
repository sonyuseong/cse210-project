using System;
using System.Collections.Generic;
using System.Threading;

class AdventureManager {
    private static string selectedItem = "";
    private static string selectedSkill = "";

    public static void StartAdventure(Player player) {
        TextAnimator.Show("You are now on a quest to fight a dragon that threatens the world. Collect items and skills to boost your stats and defeat the dragon!\n", 40);

        RunStage1_ItemSelection(player);
        RunStage2_SkillSelection(player);
        RunStage3_BossBattle(player);
    }

    private static void RunStage1_ItemSelection(Player player) {
        TextAnimator.Show("Stage 1: Choose your weapon:");
        Console.WriteLine("1. Sword (+10%)\n2. Spear (+7%)\n3. Magic Wand (+5%)");
        Console.Write("Your choice: ");
        string input = Console.ReadLine();
        switch (input) {
            case "1": selectedItem = "Sword"; break;
            case "2": selectedItem = "Spear"; break;
            case "3": selectedItem = "Magic Wand"; break;
            default: selectedItem = "Bare Hands"; break;
        }
        Console.WriteLine($"You chose: {selectedItem}\n");
    }

    private static void RunStage2_SkillSelection(Player player) {
        TextAnimator.Show("Stage 2: Choose your skill:");
        Console.WriteLine("1. Strength Buff (+10%)\n2. Slow Spell (+5%)\n3. Fire Shield (+7%)");
        Console.Write("Your choice: ");
        string input = Console.ReadLine();
        switch (input) {
            case "1": selectedSkill = "Strength Buff"; break;
            case "2": selectedSkill = "Slow Spell"; break;
            case "3": selectedSkill = "Fire Shield"; break;
            default: selectedSkill = "None"; break;
        }
        Console.WriteLine($"You learned: {selectedSkill}\n");
        player.AddSkill(new Skill(selectedSkill));
    }

    private static void RunStage3_BossBattle(Player player) {
        string[] bosses = {"Red Dragon", "Black Dragon", "Gold Dragon"};
        string boss = bosses[new Random().Next(bosses.Length)];

        TextAnimator.Show($"Stage 3: You encounter the {boss} in a final showdown!\n", 40);

        double baseChance = 0.4;
        double bonus = 0.0;

        if (selectedItem == "Sword") bonus += 0.10;
        else if (selectedItem == "Spear") bonus += 0.07;
        else if (selectedItem == "Magic Wand") bonus += 0.05;

        if (selectedSkill == "Strength Buff") bonus += 0.10;
        else if (selectedSkill == "Slow Spell") bonus += 0.05;
        else if (selectedSkill == "Fire Shield") bonus += 0.07;

        double finalChance = baseChance + bonus;

        TextAnimator.Show($"Your total win chance: {(int)(finalChance * 100)}%\n", 40);

        switch (selectedItem) {
            case "Sword":
                TextAnimator.Show("You grip your sword tightly...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("You charge at the dragon with a roar...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("You slash the sword through the air...", 40);
                break;
            case "Spear":
                TextAnimator.Show("You position your spear...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("You lunge forward with precision...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("The spear pierces toward the dragon's scales...", 40);
                break;
            case "Magic Wand":
                TextAnimator.Show("You whisper an incantation...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("The wand glows with magical energy...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("A fireball bursts forth toward the dragon...", 40);
                break;
            default:
                TextAnimator.Show("You raise your fists and run toward the dragon...", 40);
                Thread.Sleep(600);
                TextAnimator.Show("You punch wildly hoping to land a hit...", 40);
                break;
        }

        Thread.Sleep(800);
        TextAnimator.Show("The dragon roars and takes damage...", 40);
        Thread.Sleep(800);
        TextAnimator.Show("Smoke fills the battlefield...", 40);
        Thread.Sleep(800);

        bool win = new Random().NextDouble() < finalChance;

        if (win) {
            TextAnimator.Show($"You defeated the {boss}! Victory!\n", 40);
        } else {
            TextAnimator.Show($"You were defeated by the {boss}.\n", 40);
            player.ReduceHealth(100);
        }
    }
}