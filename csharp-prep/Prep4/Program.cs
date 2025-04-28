using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<int> numbers = new List<int>();
        int number = 1;

        while (number != 0){
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number > 0){
                numbers.Add(number);
            }
        }

        int sum = 0;
        foreach(int num in numbers){
            sum = sum + num;
        }
        Console.WriteLine($"The Sum is: {sum}");

        float average = 0;
        average = sum/numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largestNumber = 0;
        foreach(int num in numbers){
            if (largestNumber < num){
                largestNumber = num;
            }
        }
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}