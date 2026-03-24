using System.Collections.Generic;

namespace Library.MVC.Models
{
    public class Book
    {
        // Primary key (unique ID for each book)
        public int Id { get; set; }

        // Book title
        public string Title { get; set; } = string.Empty;

        // Book author
        public string Author { get; set; } = string.Empty;

        // Unique book identifier
        public string Isbn { get; set; } = string.Empty;

        // Category/genre of the book
        public string Category { get; set; } = string.Empty;

        // Shows if the book is available to borrow
        public bool IsAvailable { get; set; } = true;

        // Navigation property (1 Book → Many Loans)
        public List<Loan> Loans { get; set; } = new();
    }
}