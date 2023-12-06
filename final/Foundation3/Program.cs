using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("324 address road", "Burnaby", "OR", "USA");
        Address address2 = new Address("4793 Tulip Street", "Salt Lake City", "UT", "USA");
        Address address3 = new Address("5614 Kwantlen Court", "Bakersfield", "CA", "USA");
        
        Event lecture = new Lecture("Canadian Speaker Fest", "Hear a Canadian Speaker first hand in USA!", address1, "8/5/2023", "12:00pm", "Jordan Peterson");
        lecture.SetCapacity(350);
        Event reception = new Reception("John and Jane's Wedding", "Come join John and Jane on their special day!", address2, "9/12/2024", "11:00am");
        Event outdoor = new Outdoor("Day of Belief", "Come join the local county residents in celebrating everyone's individual beliefs by spending the day with family and people of faith.", address3, "12/3/4", "5:00pm", "Cloudy");
        
        Console.WriteLine("Short Descriptions:");
        Console.WriteLine(lecture.ShortDescription());
        Console.WriteLine(reception.ShortDescription());
        Console.WriteLine(outdoor.ShortDescription());

        Console.WriteLine("\nStandard Details:");
        Console.WriteLine(lecture.StandardDetails()+"\n");
        Console.WriteLine(reception.StandardDetails()+"\n");
        Console.WriteLine(outdoor.StandardDetails()+"\n");
        
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.FullDetails()+"\n");
        Console.WriteLine(reception.FullDetails()+"\n");
        Console.WriteLine(outdoor.FullDetails()+"\n");
    }
}