using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letterGrade = "";
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"Your grade is: {letterGrade}");

        if (gradePercentage >= 60)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass the course. Better luck next time!");
        }
        Console.WriteLine("Thank you for using the Program. Goodbye!");
    }
}