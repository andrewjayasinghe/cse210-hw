using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity(int duration = 60) : base(duration) { }

    protected override void Start()
    {
        base.Start();

        SetActivity("Breathing");
        SetDescription("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        Console.WriteLine(ShowActivity());
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

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);

        PerformBreathingExercise(duration, futureTime);
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
            Console.WriteLine("Invalid input, redirecting to menu");
            return -1; // Return -1 to indicate an invalid duration
        }
    }

    private void PerformBreathingExercise(int duration, DateTime futureTime)
    {
        while (DateTime.Now < futureTime)
        {
            for (int i = 0; i < duration;)
            {
                PerformBreathingCycle("Breathe in...", 2, 4);
                i += 4;

                if (DateTime.Now >= futureTime)
                    break;

                PerformBreathingCycle("Breathe out...", 3, 6);
                i += 6;

                if (DateTime.Now >= futureTime)
                    break;
            }
        }
    }

    private void PerformBreathingCycle(string message, int sleepDuration, int countdownMax)
    {
        Console.Write($"\n{message} ");
        for (int countdown = 1; countdown <= countdownMax; countdown++)
        {
            Console.Write(countdown);
            if (countdown < countdownMax)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine(); // Move to the next line after the countdown
            }
            Thread.Sleep(1000);
        }
    }
}




// using System;

// class BreathingActivity : Activity
// {
//     public BreathingActivity(int duration = 60) : base(duration) { }



//     protected override void Start()
//     {
//         base.Start();
        
//         setActivity("Breathing");

//         setDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");

       

//         Console.WriteLine(showActivity());

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
//     DateTime startTime = DateTime.Now;
//     DateTime futureTime = startTime.AddSeconds(duration);
    
//     while (DateTime.Now < futureTime)
//     {   
       
//     for (int i = 0; i < duration;)
//         {
//             // Breathe in for 2 seconds
//             Console.Write($"\nBreathe in... ");
//             for (int countdown = 1; countdown <=4; countdown++)
//             {
//                 // Console.WriteLine(countdown);
//                 // Thread.Sleep(1000);
//                 Console.Write(countdown);
//                 if (countdown < 4)
//                 {
//                     Console.Write(", ");
//                 }
//                 else
//                 {
//                     Console.WriteLine(); // Move to the next line after the countdown
//                 }
//                 Thread.Sleep(1000);
//                 if (DateTime.Now >= futureTime)
//                     break;

//             }
//             i += 4;
//             if (DateTime.Now >= futureTime)
//                     break;
            

//             Console.Write($"Now Breathe out... ");
//             for (int countdown = 1; countdown <=6; countdown++)
//             {
//                 // Console.WriteLine(countdown);
//                 // Thread.Sleep(1000);
//                 Console.Write(countdown);
//                 if (countdown < 6)
//                 {
//                     Console.Write(", ");
//                 }
//                 else
//                 {
//                     Console.WriteLine(); // Move to the next line after the countdown
//                 }
//                 Thread.Sleep(1000);
//                 if (DateTime.Now >= futureTime)
//                 break;
//             }
            
//             i += 6;
            
//             }
//         }

//     }
// }
