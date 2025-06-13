// Program.cs
using System;
using System.Threading;

// Main program
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": return;
                default: Console.WriteLine("Invalid input, press Enter to try again..."); Console.ReadLine(); continue;
            }

            activity.Run();
        }
    }
}

/*
Extra Credit Note:
This implementation includes all core requirements with inheritance, clean code structure, and reusable spinner/countdown animations.
To exceed requirements, consider:
- Logging sessions
- Making spinner more dynamic
- Ensuring non-repeating prompts
*/
