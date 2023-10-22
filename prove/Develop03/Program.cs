using System;
using System.Collections.Generic;
using System.ComponentModel;

// This program has 5 Classes
// They are as follows:
// 1. ScriptureMem
// 2. SciptureCollection
// 3. Scripture
// 4. Reference
// 5. Word
public class ScriptureMem
{
    private readonly Scripture _scripture;

    public ScriptureMem(Scripture scripture)
    {
        _scripture = scripture;
    }

    public void Run()
    {
        int count = 0;

        // This is what I use to display the initial scripture and quit if selected
        while(count <= 0){
        Console.Clear();
        _scripture.Display();
        Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
        count++;
        var userInput = Console.ReadLine();
        if (userInput?.ToLower() == "quit")
                Environment.Exit(0);
        
        }
    
        // This is what I use to run the loop that covers words when enter is pressed and quit
        while (!_scripture.IsComplete())
        {
            Console.Clear();
            _scripture.HideRandomWord();
            _scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
            var userInput = Console.ReadLine();

            if (userInput?.ToLower() == "quit")
                Environment.Exit(0);
        }
        
    }

    public static void Main()
    {
                
       
        var collection = new ScriptureCollection();

        //Add Titles
        collection.AddTitle("John 3:16");
        collection.AddTitle("Proverbs 3:5-6");
        collection.AddTitle("1 Nephi 3:10");
        
        // Add scriptures
        collection.AddScripture("For God so loved the world that he gave his one and only Son, that whosoever believeth in him should not perish, but have everlasting life.");
        collection.AddScripture("Let not mercy and truth forsake thee: bind them about thy neck; write them upon the table of thine heart; So shalt thou find favour and good understanding in the sight of God and man. Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        collection.AddScripture("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");

        //initiating my 2 lists one for holding the tiles, other for holding the verses
        List<string> allTitles = collection.GetAllTitles();
        List<string> allScriptures = collection.GetAllScriptures();
        
        // creating a randdom number between 0 to the count of the length of the list -1 since the index of the last one is 2
        var random = new Random();
        int randomIndex = random.Next(0, (allTitles.Count-1));
        var scriptureToUse = allScriptures[randomIndex];
        var scriptureTitleToUse = allTitles[randomIndex];

        var reference = new Reference(scriptureTitleToUse);
        var scripture = new Scripture(reference, scriptureToUse);
        var ScriptureMem = new ScriptureMem(scripture);

        ScriptureMem.Run();
    }
}

// This is my class which creates and holds my lists
public class ScriptureCollection
{
    private List<string> scriptureList = new List<string>();
    private List<string> titleList = new List<string>();

    public void AddScripture(string scripture)
    {
        scriptureList.Add(scripture);
    }

    public void AddTitle(string title)
    {
        titleList.Add(title);
    }

    public void RemoveScripture(string scripture)
    {
        scriptureList.Remove(scripture);
    }

    public List<string> GetAllScriptures()
    {
        return scriptureList;
    }
    public List<string> GetAllTitles()
    {
        return titleList;
    }
}



public class Scripture
{
    private readonly List<Word> _words;
    private int _hiddenWordCount;

    public Reference Reference { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
    
    //This is the method that hides a random word in the given scripture phrase
    public void HideRandomWord()
    {
        var random = new Random();
        Word wordToHide;

        do
        {
            int randomIndex = random.Next(0, _words.Count);
            wordToHide = _words[randomIndex];
        } while (wordToHide.IsHidden);

        wordToHide.Hide();
        _hiddenWordCount++;
    }

    //This method is what i use to change the bool value which closes the program if all the words in the scripture are hidden
    public bool IsComplete()
    {
        return _hiddenWordCount >= _words.Count;
    }

    public void Display()
    {
        Console.WriteLine(Reference);
        foreach (var word in _words)
        {
            Console.Write(word.ToString() + " ");
        }
        Console.WriteLine();
    }
}

public class Reference
{
    public string Text { get; }

    public Reference(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
    // This method hides my scripture words or does display the text if isHidden is false
    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}
