using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What is the magic number? ");
        // string magic_number = Console.ReadLine();
        // int integer = int.Parse(magic_number);
        Random random_num = new Random();
        int integer = random_num.Next(1,101);
        Console.WriteLine($"{integer}");
        int guessed_integer = -1;

        while(guessed_integer != integer){

        Console.WriteLine("What is your guess? ");
        string guessed_value = Console.ReadLine();
        guessed_integer = int.Parse(guessed_value);

        if (guessed_integer > integer){
            Console.WriteLine("Lower");
        }
        else if (guessed_integer < integer){
            Console.WriteLine("Higher");

        }
        else if(guessed_integer == integer){
            Console.WriteLine("You guessed it!");

        }
               
        }
    }
}