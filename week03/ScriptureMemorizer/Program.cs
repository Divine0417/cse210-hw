using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main()
        {
            var scriptures = LoadScripturesFromFile("scriptures.txt");
            var random = new Random();
            var scripture = scriptures[random.Next(scriptures.Count)];

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                    break;
                scripture.HideRandomWords();
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Program ended.");
        }

        static List<Scripture> LoadScripturesFromFile(string filepath)
        {
            var scriptures = new List<Scripture>();

            foreach (string line in File.ReadAllLines(filepath))
            {
                var parts = line.Split('|');
                var referencePart = parts[0].Trim();
                var text = parts[1].Trim();

                // Example: "Proverbs 3:5-6"
                var bookAndChapter = referencePart.Split(':')[0];
                var versePart = referencePart.Split(':')[1];

                var bookWords = bookAndChapter.Split(' ');
                string book = string.Join(" ", bookWords.Take(bookWords.Length - 1));
                int chapter = int.Parse(bookWords.Last());

                // Handle single verse or verse range
                if (versePart.Contains('-'))
                {
                    var verses = versePart.Split('-').Select(int.Parse).ToArray();
                    var reference = new Reference(book, chapter, verses[0], verses[1]);
                    scriptures.Add(new Scripture(reference, text));
                }
                else
                {
                    int verse = int.Parse(versePart);
                    var reference = new Reference(book, chapter, verse);
                    scriptures.Add(new Scripture(reference, text));
                }
            }

            return scriptures;
        }
    }

    public class Reference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _startVerse;
        private readonly int _endVerse;

        public Reference(string book, int chapter, int verse)
            : this(book, chapter, verse, verse)
        {
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            return _startVerse == _endVerse
                ? $"{_book} {_chapter}:{_startVerse}"
                : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }

    public class Word(string text)
    {
        private readonly string _text = text;
        private bool _isHidden = false;

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }

    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private readonly Random _random = new();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = [..text.Split(' ').Select(w => new Word(w))];
        }

        public void HideRandomWords(int count = 3)
        {
            var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public string GetDisplayText()
        {
            return _reference.GetDisplayText() + " " + string.Join(" ", _words.Select(w => w.GetDisplayText()));
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}