using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FileHandler {
    public static void SaveSkills(List<Skill> skills, string filename) {
        try {
            File.WriteAllLines(filename + ".txt", skills.Select(s => s.Name));
            Console.WriteLine($"Saved to {filename}.txt successfully.");
        } catch (Exception ex) {
            Console.WriteLine("Failed to save file: " + ex.Message);
        }
    }

    public static List<Skill> LoadSkills(string filename) {
        string path = filename + ".txt";
        try {
            if (!File.Exists(path)) {
                Console.WriteLine($"File '{path}' not found.");
                return new List<Skill>();
            }
            var skills = File.ReadAllLines(path).Select(line => new Skill(line)).ToList();
            Console.WriteLine($"Loaded {skills.Count} skills from {path}.");
            return skills;
        } catch (Exception ex) {
            Console.WriteLine("Failed to load file: " + ex.Message);
            return new List<Skill>();
        }
    }
}
