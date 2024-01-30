namespace BookXample;

internal static class Program
{
    internal static void Main()
    {
        Book myBook1 = new Book("The Fellowship if the Ring")
        {
            NumberOfPages = 4332
        };
        Book myBook2 = new Book("C#", "Craig Marais", "Gokstad Akademiet");
        Book emptyBook = new Book(" ");
        Console.WriteLine(myBook1.Read(3));
        Console.WriteLine("Title: " + myBook1.Title);
        Console.WriteLine(myBook2.Title + " - " + myBook2.Author);
        Console.WriteLine(emptyBook.Title);
    }
}