using Library.MVC.Models;

namespace Library.MVC.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Books.Any())
            {
                return; // database already seeded
            }

            context.Books.AddRange(
                new Book { Title = "Atomic Habits", Author = "James Clear", Isbn = "9780735211292", Category = "Self Help", IsAvailable = true },
                new Book { Title = "Clean Code", Author = "Robert C. Martin", Isbn = "9780132350884", Category = "Technology", IsAvailable = true },
                new Book { Title = "The Alchemist", Author = "Paulo Coelho", Isbn = "9780061122415", Category = "Fiction", IsAvailable = true },
                new Book { Title = "Rich Dad Poor Dad", Author = "Robert Kiyosaki", Isbn = "9781612680194", Category = "Finance", IsAvailable = true }
            );

            context.SaveChanges();
        }
    }
}