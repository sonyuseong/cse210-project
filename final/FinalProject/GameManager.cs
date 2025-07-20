using System;

class GameManager
{
    private Player player;

    public GameManager()
    {
        player = new Player();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("====== Text Roguelike Menu ======");
            Console.WriteLine("1. Start Adventure");
            Console.WriteLine("2. Show Skills");
            Console.WriteLine("3. Load Skills");
            Console.WriteLine("4. Save Skills");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    AdventureManager.StartAdventure(player);
                    Console.WriteLine("\nPress any key to return to menu.");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("\nCurrent Skills:");
                    foreach (Skill skill in player.GetSkills())
                        Console.WriteLine("- " + skill.Name);
                    Console.WriteLine("\nPress any key to return to menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Enter file name to load skills from: ");
                    string loadFile = Console.ReadLine();
                    player.ClearSkills();
                    player.AddSkills(FileHandler.LoadSkills(loadFile));
                    Console.WriteLine("Skills loaded.\nPress any key to return to menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Enter file name to save skills to: ");
                    string saveFile = Console.ReadLine();
                    FileHandler.SaveSkills(player.GetSkills(), saveFile);
                    Console.WriteLine("Skills saved.\nPress any key to return to menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
