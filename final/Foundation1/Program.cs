using System;

class Program{
    static void InitializeProgram(List<Video> videoList)
    {
        Comment comment1;Comment comment2;Comment comment3;
        Video video;List<Comment> commentList;

        comment1 = new Comment("Jimmy Smith", "I am not a huge fan of this video.");
        comment2 = new Comment("Ace Ventura", "Hope this was helpful! watch his other tutorials");
        comment3 = new Comment("Alex Jones", "This is such a helpful video!");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("MyGuy Tutorials",
        "How to change your oil.", 6000, commentList);
        videoList.Add(video);

        comment1 = new Comment("Alex Bobby", "Beautiful cover, thank you so much!");
        comment2 = new Comment("Garet Wong", "Not the worst things I've heard...");
        comment3 = new Comment("John Jones", "Try harder!");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("Drake Sings",
        "Hip Hop - Cover.", 4000, commentList);
        videoList.Add(video);

        comment1 = new Comment("GoogleSpecs", "Thanks man, I was really struggling with passing my coding classes!");
        comment2 = new Comment("Not An Apple Buyer", "Could you do something similar but with C#?");
        comment3 = new Comment("AlexTheGreat", "I appreciate the video, but I think the program idea presented would be better if it was done in python.");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("Jerry Codes",
        "Coding 101 - Program with classes", 8000, commentList);
        videoList.Add(video);
    }
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>{};
        InitializeProgram(videoList);
        foreach(Video video in videoList)
        {
            video.Display();
            Console.WriteLine();
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}