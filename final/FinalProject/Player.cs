using System.Collections.Generic;

class Player {
    private Stat stats = new Stat();
    private int health = 100;
    private List<Skill> skills = new List<Skill>();

    public void ResetForNewAdventure() {
        stats.Reset();
        health = 100;
    }

    public void AddSkill(Skill skill) => skills.Add(skill);
    public void AddSkills(List<Skill> newSkills) => skills.AddRange(newSkills);
    public void ClearSkills() => skills.Clear();
    public int GetHealth() => health;
    public void ReduceHealth(int amount) => health -= amount;
    public Stat GetStats() => stats;
    public List<Skill> GetSkills() => skills;
}
