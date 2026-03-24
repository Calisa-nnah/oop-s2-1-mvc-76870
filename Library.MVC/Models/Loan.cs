using System;

namespace Library.MVC.Models
{
    public class Loan
    {
        // Primary key (unique ID for each loan)
        public int Id { get; set; }

        // Foreign key linking to Book
        public int BookId { get; set; }

        // Navigation property (Loan → Book)
        public Book? Book { get; set; }

        // Foreign key linking to Member
        public int MemberId { get; set; }

        // Navigation property (Loan → Member)
        public Member? Member { get; set; }

        // Date when the book was borrowed
        public DateTime LoanDate { get; set; } = DateTime.Today;

        // Date when the book should be returned
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);

        // Nullable → null means not returned yet
        public DateTime? ReturnedDate { get; set; }
    }
}