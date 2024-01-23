namespace Basics
{
    /// <summary>
    /// Morten's Book class
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book constructor
        /// </summary>
        /// <param name="name">The books name</param>
        /// <param name="author">The books author</param>
        public Book(string name, string author)
        {
            this.name = name;
            this.author = author;
        }

        public string PrintLabel()
        {
            string label = "";
            label += author + " - " + name;
            return label;
        }
        // variable type styring, called name, type private
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
        
        // variable type styring, called author, type private
        private string author;

        public string Author
        { get; set; }
    }
}