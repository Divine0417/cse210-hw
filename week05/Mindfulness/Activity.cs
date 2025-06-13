using System;

abstract class Activity
{
    protected int duration;
    protected string name;
    protected string description;

    public void Run()
    {
        DisplayStartMessage();
        PerformActivity();
        DisplayEndMessage();
    }

    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {name}.");
        Console.WriteLine(description);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {name} for {duration} seconds.");
        ShowSpinner(3);
    }

    protected static void ShowSpinner(int seconds)
    {
        string[] spinner = new[] { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            System.Threading.Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    protected abstract void PerformActivity();
}
