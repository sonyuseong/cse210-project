using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,100);
        bool isContinue = true;
        do{
            Console.Write("What is your guess? ");
            string answer = Console.ReadLine();
            int number = int.Parse(answer);

            if (number == magicNumber){
                Console.WriteLine("You guessed it!");
                isContinue = false;
            }else if (number > magicNumber){
                Console.WriteLine("Lower");
            }else{
                Console.WriteLine("Higher");
            }
        }while (isContinue);
        
    }
}