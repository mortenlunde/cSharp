namespace Basics
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, World!");
            
            // This name is only for me
            Book tac = new Book("Thinking as Computation", "H. Levesque");
            Book lotr1 = new Book("The Fellowship of the Ring", "J.R.R Tolkien");
            Book lotr2 = new Book("Two towers", "J.R.R Tolkien");
            Book lotr3 = new Book("Return of the King", "J.R.R Tolkien");
            List<Book> myBooks = new List<Book>();
            myBooks.Add(lotr1);
            myBooks.Add(lotr2);
            myBooks.Add(lotr3);

            foreach (Book book in myBooks)
            {
                if (book.Name.Contains("Ring"))
                {
                    Console.WriteLine("Found a ring- book.");
                    Console.WriteLine(book.PrintLabel());
                }
                Console.WriteLine(book.Name);
            }
            // tac.name = "Thinking as Computation";
            // tac.author = "H. Levesque";
            if (tac.Name == "Thinking as Computation")
            {
                Console.WriteLine("Found the book!");
            }
            if (lotr1.Author == "J.R.R Tolkien")
            {
                Console.WriteLine("Found the book!");
            }
        }
    }
}