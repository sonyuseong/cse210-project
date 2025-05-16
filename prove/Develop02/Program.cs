using System;

/*
I used my creativity to make the journal save as a .txt file instead of a .csv file.

*/
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Journal journal = new Journal();
        bool isExit = false;
        while (!isExit)
        {
            menu.showMenu();
            Console.Write("Number: ");
            string selectMenu = Console.ReadLine();
            Console.WriteLine();
            switch (int.Parse(selectMenu))
            {
                case 1:
                    journal.WriteEntry();
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    journal.SaveEntry();
                    break;
                case 4:
                    journal.LoadEntry();
                    break;
                case 5:
                    Console.WriteLine("Good Bye!");
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("select menu again.");
                    break;
            }
        }
    }
}