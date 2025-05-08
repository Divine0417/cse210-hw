using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.WriteLine("This is a simple C# program to demonstrate the structure of a console application.");
        Console.WriteLine("");

        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name ");
        string lastName = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine($"Your name is {firstName}, {lastName} {firstName}.");
    }
}