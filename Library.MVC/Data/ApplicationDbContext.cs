// Import ASP.NET Identity (for authentication & user management)
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// Import Entity Framework Core (for database operations)
using Microsoft.EntityFrameworkCore;

// Import your Models (Book, Member, Loan)
using Library.MVC.Models;

namespace Library.MVC.Data
{
    // This class represents your DATABASE CONTEXT
    // It connects your application to the database
    // IdentityDbContext = includes built-in tables for users, login, roles etc.
    public class ApplicationDbContext : IdentityDbContext
    {
        // Constructor: receives database configuration (connection string etc.)
        // and passes it to the base IdentityDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // These represent TABLES in your database

        // Books table
        public DbSet<Book> Books { get; set; } = default!;

        // Members table
        public DbSet<Member> Members { get; set; } = default!;

        // Loans table (relationship between Book and Member)
        public DbSet<Loan> Loans { get; set; } = default!;

        // This method is used to configure relationships between tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Call base method (VERY IMPORTANT for Identity to work)
            base.OnModelCreating(builder);

            // Configure relationship: Loan → Book
            // A Loan has ONE Book
            // A Book can have MANY Loans
            builder.Entity<Loan>()
                .HasOne(l => l.Book)        // Each Loan has one Book
                .WithMany(b => b.Loans)    // Each Book can have many Loans
                .HasForeignKey(l => l.BookId); // Foreign key in Loan table

            // Configure relationship: Loan → Member
            // A Loan has ONE Member
            // A Member can have MANY Loans
            builder.Entity<Loan>()
                .HasOne(l => l.Member)     // Each Loan has one Member
                .WithMany(m => m.Loans)   // Each Member can have many Loans
                .HasForeignKey(l => l.MemberId); // Foreign key in Loan table
        }
    }
}