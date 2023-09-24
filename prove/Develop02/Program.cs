using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Obstacles { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<JournalEntry> journalEntries = new List<JournalEntry>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journalEntries);
                    break;
                case "2":
                    ShowJournal(journalEntries);
                    break;
                case "3":
                    Console.Write("Enter file name: ");
                    string fileNameToSave = Console.ReadLine();
                    SaveJournal(journalEntries, fileNameToSave);
                    break;
                case "4":
                    Console.Write("Enter file name to load: ");
                    string fileNameToLoad = Console.ReadLine();
                    journalEntries = LoadJournal(fileNameToLoad);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(List<JournalEntry> entries)
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could do anything today, what would it be?"
        };

        Console.WriteLine("\nSelect a prompt number (1-5): ");
        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {prompts[i]}");
        }

        int promptNumber = int.Parse(Console.ReadLine());

        if (promptNumber >= 1 && promptNumber <= 5)
        {
            Console.WriteLine($"\nWrite your response for: {prompts[promptNumber - 1]}");
            string userResponse = Console.ReadLine();

            Console.WriteLine("\nAre there any obstacles preventing you from writing in your journal? (Yes/No)");
            string obstaclesAnswer = Console.ReadLine();        

            JournalEntry entry = new JournalEntry
            {
                Prompt = prompts[promptNumber - 1],
                Response = userResponse,
                Obstacles = obstaclesAnswer,
                Date = DateTime.Now
            };
            entries.Add(entry);
        }
        else
        {
            Console.WriteLine("\nInvalid prompt number.");
        }
    }

    static void ShowJournal(List<JournalEntry> entries)
    {
        Console.WriteLine("\nJournal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Obstacles: {entry.Obstacles}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    static void SaveJournal(List<JournalEntry> entries, string fileName)
    {
        try
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(fileName, json);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static List<JournalEntry> LoadJournal(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            List<JournalEntry> entries = JsonSerializer.Deserialize<List<JournalEntry>>(json);
            Console.WriteLine("Journal loaded successfully.");
            return entries;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
            return new List<JournalEntry>();
        }
    }
}


// This code demonstrates the effective use of the abstraction principle by creating a class called JournalEntry. This class encapsulates the various elements of a journal entry, including the question, the answer, possible obstacles, and the date. Thanks to this abstraction, a more orderly management of the inputs is achieved and their manipulation in the various functions of the program is facilitated.


// The decision to use the JSON format to serialize and deserialize journal entries is a smart choice. JSON is a data exchange format that is lightweight and readable, making it an effective option for saving and retrieving journal information in files. Additionally, .NET offers built-in libraries to perform JSON serialization and deserialization (as used here with System.Text.Json), which simplifies implementation.



// The addition of a section that allows the user to identify and consider obstacles that might be influencing their ability to journal is a very beneficial addition. Not only does it encourage self-awareness, but it can also help the user overcome possible emotional or practical barriers that may be affecting their writing routine.

// Additionally, this feature may be useful for detecting patterns in times when the user feels more or less motivated to write in their journal, which could lead to a deeper understanding of their habits and emotions.
