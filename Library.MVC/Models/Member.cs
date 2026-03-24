using System.Collections.Generic;

namespace Library.MVC.Models
{
    public class Member
    {
        // Primary key (unique ID for each member)
        public int Id { get; set; }

        // Full name of the member
        public string FullName { get; set; } = string.Empty;

        // Email address
        public string Email { get; set; } = string.Empty;

        // Phone number
        public string Phone { get; set; } = string.Empty;

        // Navigation property (1 Member → Many Loans)
        public List<Loan> Loans { get; set; } = new();
    }
}