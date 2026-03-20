// Import List collection (used for storing multiple items)
using System.Collections.Generic;

namespace Library.MVC.Models
{
    // This class represents the MEMBER entity (table in the database)
    public class Member
    {
        // Primary Key (unique ID for each member)
        public int Id { get; set; }

        // Member's full name
        public string FullName { get; set; } = string.Empty;

        // Member's email address
        public string Email { get; set; } = string.Empty;

        // Member's phone number
        public string Phone { get; set; } = string.Empty;

        // Navigation Property:
        // A Member can have MANY Loans
        // This creates a ONE-TO-MANY relationship (Member → Loans)
        public List<Loan> Loans { get; set; } = new();
    }
}