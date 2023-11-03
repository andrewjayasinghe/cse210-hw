using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

class ListingActivity : Activity
{
    private Stopwatch sw = new Stopwatch();
    private double lastFrame;

    public ListingActivity(int duration = 10) : base(duration) { }

    protected override void Start()
    {
        base.Start();

        SetActivity("Listing");
        Console.WriteLine(ShowActivity());

        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine(ShowDescription());

        int duration = GetActivityDurationFromUser();
        if (duration < 0)
        {
            Console.WriteLine("Invalid duration. Please enter a valid number of seconds.");
            return;
        }

        Console.Clear();
        Console.WriteLine("\nGet ready to begin...");
        Ready(4);

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        Console.WriteLine($"---{prompts[randomIndex]}---");

        Console.Write("\nYou may begin shortly");
        Wait(5);

        List<string> statementList = CollectUserInput(duration);

        int lineCount = statementList.Count(line => line == "\n");

        string statementListStr = String.Join<string>("", statementList);
        
        Console.WriteLine($"You listed {lineCount} items\n");

    }

    private int GetActivityDurationFromUser()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out int duration))
        {
            SetDuration(duration);
            return duration;
        }
        else{
            Console.WriteLine("Invalid duration. Please enter a valid number of seconds.");
            return -1; 
        }
        
    }

    private void Wait(int seconds)
    {
        for (int j = 0; j < seconds; j++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    private List<string> CollectUserInput(int duration)
    {
        this.sw.Start();
        double acc = 0.0;
        int timeSpan = duration * 1000;

        Console.Write(">");
        List<string> statementList = new List<string>();

        while (acc <= timeSpan)
        {
            acc += DeltaTime();
            if (!Console.KeyAvailable)
            {
                continue;
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("");
                statementList.Add("\n");
                Console.Write(">");
            }
            else
            {
                statementList.Add(key.KeyChar.ToString());
            }
        }
        Console.WriteLine("");
		statementList.Add("\n");

        return statementList;
    }

    private double DeltaTime()
    {
        TimeSpan ts = this.sw.Elapsed;
        double firstFrame = ts.TotalMilliseconds;
        double dt = firstFrame - lastFrame;
        this.lastFrame = ts.TotalMilliseconds;
        return dt;
    }
}



// using System;
// using System.Diagnostics;


// class ListingActivity : Activity
// {
//     public ListingActivity(int duration = 10) : base(duration) { }

//     private Stopwatch sw = new Stopwatch();
// 	private double lastFrame;

// 	private double deltaTime()
// 	{
// 		 TimeSpan ts = this.sw.Elapsed;
// 		 double firstFrame = ts.TotalMilliseconds;
            
// 		 double dt = firstFrame - lastFrame;
           
// 		 this.lastFrame = ts.TotalMilliseconds;

// 		 return dt;
// 	}

//     protected override void Start()
//     {
//         base.Start();
        
//         setActivity("Listing");
        
//         Console.WriteLine(showActivity());
//         setDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        
//         Console.WriteLine(showDescription());

//         Console.Write("How long, in seconds, would you like for your session? ");
        
//         if (int.TryParse(Console.ReadLine(), out int duration))
//         {
//             SetDuration(duration);
//         }
//           else
//         {
//             Console.WriteLine("Invalid duration. Please enter a valid number of seconds.");
//         }
        
//         Console.Clear();
//         Console.WriteLine("\nGet ready to begin...");
//         ready(4);
        

//         string[] prompts = {
//             "Who are people that you appreciate?",
//             "What are personal strengths of yours?",
//             "Who are people that you have helped this week?",
//             "When have you felt the Holy Ghost this month?",
//             "Who are some of your personal heroes?"
//         };

//         Console.WriteLine("\nList as many responses you can to the following prompt:");

//         Random random = new Random();
//         int randomIndex = random.Next(prompts.Length);
//         Console.WriteLine($"---{prompts[randomIndex]}---");

//         Console.Write("\nYou may begin shortly");

//         for (int j = 0; j < 5; j++)
//         {
//             Console.Write(".");
//             Thread.Sleep(500);
//         }
//         Console.WriteLine();
        
//         List<string> statementList = new List<string>();

//         this.sw.Start();
//         double acc = 0.0;
//         int timeSpan = duration *1000;
//         Console.Write(">");
//         while (acc <= timeSpan)
//         {
//             acc += this.deltaTime();
// 			if (!Console.KeyAvailable)
// 			{
// 				continue;
// 			}
// 			ConsoleKeyInfo key = Console.ReadKey();
// 			if (key.Key == ConsoleKey.Enter)
//             {
//                 Console.WriteLine("");
// 				statementList.Add("\n");
// 				Console.Write(">");
//             }
            
//             else
// 			{
// 				statementList.Add(key.KeyChar.ToString());
// 			}
            
//         }
//         Console.WriteLine("");
// 		statementList.Add("\n");
// 		int lineCount = statementList.Count(line => line == "\n");

//         string statementListStr = String.Join<string>("", statementList);
        
//         Console.WriteLine($"You listed {lineCount} items\n");




       
//     }
// }
