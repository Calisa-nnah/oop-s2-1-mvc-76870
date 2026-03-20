// Import List collection (used for storing multiple related records)
using System.Collections.Generic;

namespace Library.MVC.Models
{
    // This class represents the BOOK entity (table in the database)
    public class Book
    {
        // Primary Key (unique ID for each book)
        public int Id { get; set; }

        // Title of the book
        public string Title { get; set; } = string.Empty;

        // Author of the book
        public string Author { get; set; } = string.Empty;

        // ISBN (unique identifier for books globally)
        public string Isbn { get; set; } = string.Empty;

        // Category or genre of the book (e.g., Fiction, Science)
        public string Category { get; set; } = string.Empty;

        // Indicates if the book is available for borrowing
        // Default = true (book is available when first created)
        public bool IsAvailable { get; set; } = true;

        // Navigation Property:
        // A Book can have MANY Loans
        // This creates a ONE-TO-MANY relationship (Book → Loans)
        public List<Loan> Loans { get; set; } = new();
    }
}