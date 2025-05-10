using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
       
       Random randomNumberGenerator = new Random();
       int magicNUmber = randomNumberGenerator.Next(1, 101);

       int guess = -1;

        while (guess != magicNUmber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNUmber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNUmber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it right!!!");
            }
        }
    }
}
