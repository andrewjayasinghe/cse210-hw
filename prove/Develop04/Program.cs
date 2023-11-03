using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        ActivityManager activityManager = new ActivityManager();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Breathing Activity");
            Console.WriteLine(" 2. Reflection Activity");
            Console.WriteLine(" 3. Listing Activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

           if (choice == "1")
                {
                    activityManager.StartActivity(new BreathingActivity());
                }
                else if (choice == "2")
                {
                    activityManager.StartActivity(new ReflectionActivity());
                }
                else if (choice == "3")
                {
                    activityManager.StartActivity(new ListingActivity());
                }
                else if (choice == "4")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose a valid activity.");
            }
        }
    }
}








