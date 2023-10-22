using System;
using System.Collections.Generic;
using System.ComponentModel;

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

    
        while(count <= 0){
        Console.Clear();
        _scripture.Display();
        Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
        count++;
        var userInput = Console.ReadLine();
        if (userInput?.ToLower() == "quit")
                Environment.Exit(0);
        
        }
    

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
        // Adding multiple scriptures that are selected at random to show the user to memmorize
        // This is that code for it
        List<string> scriptureList = new List<string>();  
        scriptureList.Add("For God so loved the world that he gave his one and only Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scriptureList.Add("Let not mercy and truth forsake thee: bind them about thy neck; write them upon the table of thine heart; So shalt thou find favour and good understanding in the sight of God and man. Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        scriptureList.Add("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        
        List<string> scriptureTitleList = new List<string>();  
        scriptureTitleList.Add("John 3:16");
        scriptureTitleList.Add("Proverbs 3:5-6");
        scriptureTitleList.Add("1 Nephi 3:10");
        var random = new Random();
        int randomIndex = random.Next(0, scriptureList.Count);
        var scriptureToUse = scriptureList[randomIndex];
        var scriptureTitleToUse = scriptureTitleList[randomIndex];

        var reference = new Reference(scriptureTitleToUse);
        var scripture = new Scripture(reference, scriptureToUse);
        var ScriptureMem = new ScriptureMem(scripture);

        ScriptureMem.Run();
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

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}
