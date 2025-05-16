using System;
using System.Collections.Generic;
using System.IO;


    public class Journal
    {
        public List<(DateTime date, string prompt, string content)> entries = new();
        public PromptGenerator promptGenerator = new PromptGenerator();

    public void WriteEntry()
    {
        string prompt = promptGenerator.RandomGenerator();
        DateTime now = DateTime.Now;

        Console.WriteLine($"\n[{now:yyyy-MM-dd}]");
        Console.WriteLine("Prompt: " + prompt);

        string line;
        string fullText = "";

        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) break;
            fullText += line + Environment.NewLine;
        }

        entries.Add((now, prompt, fullText));
        Console.WriteLine("Your Entry saved temporary. Select number 2.");
        Console.WriteLine("If you want to save to a file. Select Nubmer 3.");
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("There is entry now.");
                return;
            }

            Console.WriteLine("\n Your Journal:");
            foreach (var (date, prompt, content) in entries)
            {
                Console.WriteLine($"[{date:yyyy-MM-dd HH:mm}]");
                Console.WriteLine($"Prompt: {prompt}");
                Console.WriteLine(content);
            }
        }

        public void SaveEntry()
        {
            Console.Write("What is the file name? ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName, append: true))
            {
                foreach (var (date, prompt, content) in entries)
                {
                    writer.WriteLine($"[{date:yyyy-MM-dd HH:mm}]");
                    writer.WriteLine($"Prompt: {prompt}");
                    writer.WriteLine(content);
                    writer.WriteLine();
                }
            }

            entries.Clear();
            Console.WriteLine("Your Journal saved.");
        }

        public void LoadEntry()
        {
            Console.Write("What is the filename?: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                Console.WriteLine($"\nJournal <{fileName}>");
                Console.WriteLine(File.ReadAllText(fileName));
            }
            else
            {
                Console.WriteLine("Filename Error.");
            }
        }
    }

