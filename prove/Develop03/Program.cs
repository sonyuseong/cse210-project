using System;
using System.Collections.Generic;
using System.Linq;



/// I created a hint feature as a functionality that goes beyond the basic requirements. When the user types "hint", the previously hidden words reappear for 5 seconds to help the user with memorization.


class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1 Nephi", 1, 1, 2);
        string text = "I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my days, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days. Yea, I make a record in the language of my father, which consists of the learning of the Jews and the language of the Egyptians.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to continue or type hint to see the answer or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (input == "hint")
            {
                Console.Clear();
                Console.WriteLine(scripture.GetOriginalText());
                Thread.Sleep(5000);
                continue;
            }

            scripture.HideRandomWords();


        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}

