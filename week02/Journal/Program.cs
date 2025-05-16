using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; } 
    public string Mood { get; set; } // Allow the user to add a mood to the entry

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = "Neutral"; // Default mood
    }

    public JournalEntry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"[{Date}] ({Mood})\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}";
    // Use '|' as a delimiter for file format
    }

    // Convert entry to CSV format
    public string ToCsvFormat()
    {
        // Escape quotes by doubling them
        static string Escape(string s) => $"\"{s.Replace("\"", "\"\"")}\"";
        return $"{Escape(Date)},{Escape(Prompt)},{Escape(Response)},{Escape(Mood)}";
    }

    public static JournalEntry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new JournalEntry(parts[0], parts[1], parts[2], parts.Length > 3 ? parts[3] : "Neutral");
        // Default mood to "Neutral" if not provided
    }

    public static JournalEntry FromCsvFormat(string csvLine)
    {
        // Basic CSV parser using split by ","
        string pattern = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
        string[] parts = System.Text.RegularExpressions.Regex.Split(csvLine, pattern);

        string date = Unescape(parts[0]);
        string prompt = Unescape(parts[1]);
        string response = Unescape(parts[2]);
        string mood = Unescape(parts[3]);

        return new JournalEntry(date, prompt, response, mood);
    }

    // Unwrap quotes and unescape
    private static string Unescape(string input)
    {
        if (input.StartsWith('\"') && input.EndsWith('\"'))
        {
            input = input[1..^1];
        }
        return input.Replace("\"\"", "\"");
    }
}

class Journal
{
    private readonly List<JournalEntry> _entries = new();

    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo journal entries to display.");
            return;
        }

        foreach (JournalEntry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        //save to main file
        using (StreamWriter writer = new(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }

        Console.WriteLine($"\nJournal saved to '{filename}' successfully!");

        //save to backup file
        string backupFolder = "Backup";
        if (!Directory.Exists(backupFolder))
        {
            Directory.CreateDirectory(backupFolder);
        }

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string backupFile = Path.Combine(backupFolder, $"journal_backup_{timestamp}.txt");

        using (StreamWriter writer = new(backupFile))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($"\nBackup created at '{backupFile}' successfully!");
    }

    public void SaveToCsv(string filename)
    {
        using (StreamWriter writer = new(filename))
        {
            foreach (JournalEntry entry in _entries)
            {
                writer.WriteLine(entry.ToCsvFormat());
            }
        }

        Console.WriteLine($"Journal saved as CSV to '{filename}'.");
    }

    public void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                _entries.Add(JournalEntry.FromCsvFormat(line));
            }
        }

        Console.WriteLine($"Journal loaded from CSV file '{filename}'.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _entries.Add(JournalEntry.FromFileFormat(line));
            }
            Console.WriteLine($"\nJournal loaded from '{filename}' successfully!");
        }
        else
        {
            Console.WriteLine($"\nFile '{filename}' does not exist.");
        }
    }
}

class PromptGenerator
{
    private static readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today that I want to remember forever?",
        "What made me smile today?",
        "What challenge did I overcome today?",
        "What am I grateful for right now?",
        "Describe a moment when you felt at peace today.",
        "What is something new you tried today?",
        "Who inspired you today and why?",
        "What is one thing you want to improve tomorrow?",
        "How did you help someone today?",
        "What was the most surprising thing that happened today?",
        "What did you do for self-care today?",
        "What is a goal you are working towards?",
        "What made you laugh today?",
        "What is something you wish you had done differently today?",
        "Describe a beautiful moment you experienced today."
    };

    private static readonly Random _random = new();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new();
        PromptGenerator promptGenerator = new();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Save to CSV file"); // Save to CSV
            Console.WriteLine("6. Load from CSV file"); // Load from CSV
            Console.WriteLine("7. Exit");
            Console.Write("What would you like to do? (1–7): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    //New feature: Ask for mood
                    Console.WriteLine("How are you feeling today? Select a mood: ");
                    var moods = new[] { "Happy", "Sad", "Angry", "Excited", "Nervous", "Relaxed" };
                    for (int i = 0; i < moods.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {moods[i]}");
                    }
                    Console.Write("Select a mood (1-6): ");
                    int moodChoice = int.Parse(Console.ReadLine());
                    string selectedMood = moodChoice >= 1 && moodChoice <= moods.Length ? moods[moodChoice - 1] : "Neutral";
                    // Set the mood for the entry

                    JournalEntry entry = new(DateTime.Now.ToString(), prompt, response, selectedMood);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added!\n");
                    // Show the journal entries after adding
                    Console.WriteLine("Your Journal Entries:");
                    journal.DisplayEntries();
                    break;

                case "2":
                    Console.WriteLine("Your Journal Entries:");
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter a filename to save to (e.g., journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter a filename to load from (e.g., journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                
                // New feature: Save to CSV
                case "5":
                    Console.Write("Enter filename to save as CSV (e.g., journal.csv): ");
                    string csvSave = Console.ReadLine();
                    journal.SaveToCsv(csvSave);
                    break;

                // New feature: Load from CSV
                case "6":
                    Console.Write("Enter filename to load from CSV: ");
                    string csvLoad = Console.ReadLine();
                    journal.LoadFromCsv(csvLoad);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Exiting journal. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter a number 1–7.");
                    break;
            }
        }
    }
}
