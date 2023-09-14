using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your percentage grade? ");
        string value = Console.ReadLine();
        int percentage = int.Parse(value);

        string grade = "";

        if (percentage >= 90){
            grade = "A";
        }

        else if (percentage>= 80){
            grade = "B";
        }

        else if (percentage>= 70){
        grade = "C";
        }

        else if (percentage>= 60){
        grade = "D";
         }

        else {
        grade = "F";
        }

        Console.WriteLine($"Your Letter grade is: {grade}");

        if (percentage >= 70){

        Console.WriteLine("Congratulations! You passed!");

        }
        else{
        
        Console.WriteLine("Good Luck next time!");

        }

    }
}