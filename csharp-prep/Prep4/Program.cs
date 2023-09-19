using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int integer = -1;
        List<int> numbers = new List<int>();

        while (integer != 0){
        
        Console.Write("Enter Number: ");
        string user_number = Console.ReadLine();
        integer = int.Parse(user_number); 
       
        if(integer!=0){
            numbers.Add(integer);
        }
        else{
            break;
        }

        }  
        
        int sum = 0;
        int max = numbers[0];
         foreach (int number in numbers)
        {
            sum += number;
             if (number > max)
            {
                max = number;
            }
        }
        
        float avg = ((float)sum)/numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
        
        
        
        
        
        
        
    
    
    
    }
}