using System;
using System.Collections.Generic;

// The Comment class represents a single comment on a video
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        CommentText = text;
    }
}

// The Video class stores information about a video and its associated comments
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

// The main program class where everything is created and displayed
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // First video
        Video video1 = new Video("How to Make Jollof Rice", "NaijaKitchen", 420);
        video1.AddComment(new Comment("Chioma", "Dis recipe sweet die!"));
        video1.AddComment(new Comment("John", "Thanks! I finally made it right."));
        video1.AddComment(new Comment("Abdul", "Can you do a fried rice one next?"));
        videos.Add(video1);

        // Second video
        Video video2 = new Video("C# Basics Tutorial", "CodeWithTayo", 780);
        video2.AddComment(new Comment("Divine", "Clear and concise. Thanks!"));
        video2.AddComment(new Comment("Lola", "I wish I found this earlier."));
        video2.AddComment(new Comment("Fred", "This helped with my assignment."));
        videos.Add(video2);

        // Third video
        Video video3 = new Video("Top 10 Nigerian Songs", "NaijaBeatz", 350);
        video3.AddComment(new Comment("Ada", "Wizkid forever 🔥"));
        video3.AddComment(new Comment("Emeka", "Where's Burna Boy? 😅"));
        video3.AddComment(new Comment("Tolu", "Great list! I added them to my playlist."));
        videos.Add(video3);

        // Fourth video
        Video video4 = new Video("Workout At Home", "FitNaija", 600);
        video4.AddComment(new Comment("Sandra", "Just finished this and I'm sweating!"));
        video4.AddComment(new Comment("Kelechi", "This is better than the gym."));
        video4.AddComment(new Comment("Uche", "Day 1: Let's gooo! 💪"));
        videos.Add(video4);

        // Display all videos and their comments
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
