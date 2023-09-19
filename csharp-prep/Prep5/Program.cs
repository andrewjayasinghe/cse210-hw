using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name,squared);

    }




    static void DisplayWelcome() {

        Console.WriteLine("Welcome to the program!");

        }



    static string PromptUserName() {

        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;

    }

    static int PromptUserNumber() {

        Console.Write("Please enter your favorite number: ");
        string reading = Console.ReadLine();
        int number = int.Parse(reading);
        return number;

    }

    static int SquareNumber(int value) {
        int square = value*value;
        return square;
    }

    static void DisplayResult(string name,int squareval) {

        Console.WriteLine($"{name}, the square of your number is {squareval}");

    }


}