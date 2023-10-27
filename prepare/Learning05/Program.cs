using System;

namespace library_demo
{
    class Program
    {
        static void main(string[] args)
        {
            Book book1 = new Book();
            book1.SetAuthor("Smith");
            book1.SetTitle("A Great Book");

            Console.WriteLine(book1.GetBookInfo());
        }
    }
}