using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program  //this is my main class
{
    static List<string> entries = new List<string>(); //initalising the primary list
    static List<string> prompts = new List<string> // this is my prompts list
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

        static void WriteNewEntry() // this function prompts the user to answer a prompt and saves it in the entries array
    {
        Console.Clear();
        Console.WriteLine("Write a new entry:");

        // Randomly select a prompt from the list
        Random random = new Random();
        string randomPrompt = prompts[random.Next(0, prompts.Count)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        // Create a formatted string entry and add it to the journal
        string entry = $"Date: {dateText}\nPrompt: {randomPrompt}\nResponse: {response}\n";

        entries.Add(entry);
        Console.WriteLine("\nEntry recorded.");
    }



        static void DisplayJournal() // this function reads all the entries in the entries array
    {
        Console.Clear();
        Console.WriteLine("Journal Entries:");
        foreach (string entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

        static void SaveJournalToFile() // This function writes all the entries in the entries array into a file which can be loaded later
    {
        Console.Clear();
        Console.Write("Enter a filename to save the journal: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (string entry in entries)
                {
                    outputFile.WriteLine(entry);
                }
            }
            Console.WriteLine($"Journal saved to '{fileName}'.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    static void LoadJournalFromFile() // This function loads entries saved to files into the entries array
    {
        Console.Clear();
        Console.Write("Enter a filename to load the journal: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            try
            {
                // Load journal entries from the file
                List<string> loadedEntries = new List<string>();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        loadedEntries.Add(line);
                    }
                }

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


}

