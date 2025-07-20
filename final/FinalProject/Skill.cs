class Skill {
    public string Name { get; private set; }

    public Skill(string name) {
        Name = name;
    }

    public override string ToString() => Name;
}
