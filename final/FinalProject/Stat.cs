class Stat {
    private int strength, agility, intelligence;

    public void Reset() {
        strength = 0;
        agility = 0;
        intelligence = 0;
    }

    public void Increase(string stat) {
        switch (stat.ToLower()) {
            case "strength": strength++; break;
            case "agility": agility++; break;
            case "intelligence": intelligence++; break;
        }
    }

    public int Get(string stat) {
        return stat.ToLower() switch {
            "strength" => strength,
            "agility" => agility,
            "intelligence" => intelligence,
            _ => 0
        };
    }
}
