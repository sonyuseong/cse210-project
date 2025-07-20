using System;

class CombatEvent {
    private int difficulty;

    public CombatEvent(int level) {
        difficulty = level;
    }

    public bool Resolve(Player player) {
        int power = player.GetStats().Get("strength") + player.GetStats().Get("agility");
        double winChance = (double)power / (power + difficulty);

        Console.WriteLine($"Your win chance: {(int)(winChance * 100)}%");
        return new Random().NextDouble() < winChance;
    }
}
