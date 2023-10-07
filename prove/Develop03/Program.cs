using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Entry> entries = new List<Entry>();
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be? ",
        "Did you make any memmories today? "
    };

    static void Main()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to my Journal Program!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();
            int choice = int.Parse(input);


            if (choice == 1)
                {
                    WriteNewEntry();
                }
            else if (choice == 2)
                {
                    DisplayJournal();
                }
            else if (choice == 3)
                {
                    SaveJournalToFile();
                }
            else if (choice == 4)
                {
                    LoadJournalFromFile();
                }
            else if (choice == 5)
                {
                    SaveJournal(); 
                    Environment.Exit(0);
                }
            else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }
           

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    static void WriteNewEntry()
    {
        Console.Clear();
        Console.WriteLine("Write a new entry:");

        // Randomly select a prompt from the list
        Random random = new Random();
        string randomPrompt = prompts[random.Next(0, (prompts.Count))];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();

        // Create a new entry and add it to the journal
        Entry entry = new Entry
        {
            Date = DateTime.Now,
            Prompt = randomPrompt,
            Response = response
        };

        entries.Add(entry);
        Console.WriteLine("\nEntry recorded.");
    }

    static void DisplayJournal()
    {
        Console.Clear();
        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    static void SaveJournalToFile()
    {
        Console.Clear();
        Console.Write("Enter a filename to save the journal: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    outputFile.WriteLine($"Date: {entry.Date:yyyy-MM-dd HH:mm:ss},");
                    outputFile.WriteLine($"Prompt: {entry.Prompt},");
                    outputFile.WriteLine($"Response: {entry.Response}\n");
                }
            }
            Console.WriteLine($"Journal saved to '{fileName}'.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    static void LoadJournalFromFile()
    {
        Console.Clear();
        Console.Write("Enter a filename to load the journal: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            try
            {
                // Load journal entries from the file
                List<Entry> loadedEntries = new List<Entry>();
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    Console.WriteLine(date);
                    Console.WriteLine(prompt);
                    Console.WriteLine(response);

                }
                // using (StreamReader reader = new StreamReader(fileName))
                // {
                //     Entry currentEntry = null;
                //     string line;
                //     while ((line = reader.ReadLine()) != null)
                //     {
                //         if (line.StartsWith("Date: "))
                //         {
                //             currentEntry = new Entry();
                //             currentEntry.Date = DateTime.ParseExact(
                //                 line.Replace("Date: ", ""), "yyyy-MM-dd HH:mm:ss", null);
                //         }
                //         else if (line.StartsWith("Prompt: ") && currentEntry != null)
                //         {
                //             currentEntry.Prompt = line.Replace("Prompt: ", "");
                //         }
                //         else if (line.StartsWith("Response: ") && currentEntry != null)
                //         {
                //             currentEntry.Response = line.Replace("Response: ", "");
                //             loadedEntries.Add(currentEntry);
                //             currentEntry = null;
                //         }
                //     }
                // }

                // Replace the current journal with the loaded entries
                entries = loadedEntries;
                Console.WriteLine($"Journal loaded from '{fileName}'.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error loading journal: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("File not found. Please enter a valid filename.");
        }
    }

    static void SaveJournal()
    {
        // Save the current journal to a default file (e.g., "journal.txt")
        SaveJournalToFile();
    }

    // static void LoadJournal()
    // {
    //     // Load the journal from a default file (e.g., "journal.txt") if it exists
    //     string defaultFileName = "journal.txt";
    //     if (File.Exists(defaultFileName))
    //     {
    //         LoadJournalFromFile();

    //     }
    // }
}

class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}
