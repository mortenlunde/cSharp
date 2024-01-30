namespace BookXample
{
    public class Book
    {
        public readonly string? Title;
        public string? Author;
        public string? Isbn;
        public string? Publisher;
        public string? Edition;
        public int? NumberOfPages;

        public Book(string title)
        {
            if (title.Length == 0 )
            {
                throw new Exception("Emty title");
            }
            this.Title = title; // Book must have a title;
        }
        public Book(string title, string author = "", string publisher = "Self published")
        {
            if (title.Length == 0 )
            {
                throw new Exception("Emty title");
            }
            this.Title = title; // Book must have a title;
            this.Author = author;
            this.Publisher = publisher;
        }

        internal string Read(int pageNumber)
        {
            return pageNumber <= NumberOfPages ? "See Spot Run." : "Page not found.";
        }
    }
}