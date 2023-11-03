using System;
using System.Threading;

class ReflectionActivity : Activity
{
    public ReflectionActivity(int duration = 20) : base(duration) { }

    protected override void Start()
    {
        base.Start();
        SetActivity("Reflection");
        Console.WriteLine(ShowActivity());
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine(ShowDescription());
        
        int duration = GetActivityDurationFromUser();

        if (duration > 0)
        {
            Console.Clear();
            Console.WriteLine("\nGet ready to begin...");
            Ready(3);
            Console.WriteLine("\n");
            Console.WriteLine("Consider the following prompt: \n");
            string[] prompts = {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            Random random = new Random();
            int randomIndex = random.Next(prompts.Length);
            Console.WriteLine($"---{prompts[randomIndex]}---");
            Console.Write("\nWhen you have something in mind, press enter to continue...");
            Console.ReadKey();

            Console.Write("\nNow ponder on each of the following questions as they relate to this experience.");
            Console.Write("\nYou may begin shortly");
            Wait(5);

            Console.Clear();
            string[] reflectionQuestions = {
                "> Why was this experience meaningful to you?",
                "> Have you ever done anything like this before?",
                "> How did you get started?",
                "> How did you feel when it was complete?",
                "> What made this time different than other times when you were not as successful?",
                "> What is your favorite thing about this experience?",
                "> What could you learn from this experience that applies to other situations?",
                "> What did you learn about yourself through this experience?",
                "> How can you keep this experience in mind in the future?"
            };

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(duration);

            DisplayReflectionQuestions(reflectionQuestions, futureTime);
        }
    }

    private int GetActivityDurationFromUser()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
        {
            SetDuration(duration);
            return duration;
        }
        else
        {
            Console.WriteLine("Invalid duration. Please enter a valid number of seconds.");
            return -1; 
        }
    }

    private void Wait(int seconds)
    {
        for (int j = 0; j < seconds; j++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
    }

    private void DisplayReflectionQuestions(string[] questions, DateTime futureTime)
    {
        Random random = new Random();
        List<int> indexes = new List<int>();

        while (DateTime.Now < futureTime)
        {
            for (int j = 0; j < questions.Length; j++)
            {   
                int randomIndex;
                do
                {
                    randomIndex = random.Next(questions.Length);
                }
                while (indexes.Contains(randomIndex));
                
                indexes.Add(randomIndex);

                Console.Write($"{j + 1}. {questions[randomIndex]}");
                Wait(5);
                if (DateTime.Now >= futureTime)
                    break;
                Console.WriteLine("\n");

                // This section of code in my program makes sure that the reflection prompts are displayed at random and do not replicate themselves
                
                }
                
            }
        }
    }





// using System;

// class ReflectionActivity : Activity
// {
//     public ReflectionActivity(int duration = 20) : base(duration) { }

//     protected override void Start()
//     {
//         base.Start();
//         setActivity("Reflection");

//         Console.WriteLine(showActivity());
//         setDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        
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
//         ready(3);
//         Console.WriteLine("\n");
//         Console.WriteLine("Consider the following prompt: \n");


//         string[] prompts = {
//             "Think of a time when you stood up for someone else.",
//             "Think of a time when you did something really difficult.",
//             "Think of a time when you helped someone in need.",
//             "Think of a time when you did something truly selfless."
//         };

//         Random random = new Random();

    
//         int randomIndex = random.Next(prompts.Length);
//         Console.WriteLine($"---{prompts[randomIndex]}---");
//         Console.Write("\nWhen you have something in mind, press enter to continue...");
//         Console.ReadKey();

//         Console.Write("\n Now ponder on each of the following questions as they relate to this experience.");
//         Console.Write("\n You may begin shortly");

//         for (int j = 0; j < 5; j++)
//         {
//             Console.Write(".");
//             Thread.Sleep(500);
//         }
//         Console.WriteLine();

//         Console.Clear();

//         string[] reflectionQuestions = {
//             "> Why was this experience meaningful to you?",
//             "> Have you ever done anything like this before?",
//             "> How did you get started?",
//             "> How did you feel when it was complete?",
//             "> What made this time different than other times when you were not as successful?",
//             "> What is your favorite thing about this experience?",
//             "> What could you learn from this experience that applies to other situations?",
//             "> What did you learn about yourself through this experience?",
//             "> How can you keep this experience in mind in the future?"
//         };

//         DateTime startTime = DateTime.Now;
//         DateTime futureTime = startTime.AddSeconds(duration);
        
//         while (DateTime.Now < futureTime)
//         {
//             for (int j = 0; j < reflectionQuestions.Length; j++)
//             {
//                 Console.Write($"{j + 1}. {reflectionQuestions[j]}");
//                  for (int i = 0; i < 5; i++)
//                     {
//                         Console.Write(".");
//                         Thread.Sleep(1000);
//                         if (DateTime.Now >= futureTime)
//                             break;
//                     }
                
//                 if (DateTime.Now >= futureTime)
//                     break;
//                 Console.WriteLine("\n");

//             }
            
//         }
        
        

//         }
//     }


