using System;
using System.Collections.Generic;

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
