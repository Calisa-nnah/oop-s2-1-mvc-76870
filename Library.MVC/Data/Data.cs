using Bogus;
using Library.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.MVC.Data
{
    public static class Data
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            await context.Database.MigrateAsync();

            // Create Admin role
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create Admin user
            var adminEmail = "admin@library.local";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Seed Books
            if (!await context.Books.AnyAsync())
            {
                var bookFaker = new Faker<Book>()
                    .RuleFor(b => b.Title, f => f.Lorem.Sentence(3))
                    .RuleFor(b => b.Author, f => f.Name.FullName())
                    .RuleFor(b => b.Isbn, f => f.Random.ReplaceNumbers("978##########"))
                    .RuleFor(b => b.Category, f => f.PickRandom("Fiction", "Science", "History", "Technology"))
                    .RuleFor(b => b.IsAvailable, true);

                var books = bookFaker.Generate(20);

                context.Books.AddRange(books);
                await context.SaveChangesAsync();
            }

            // Seed Members
            if (!await context.Members.AnyAsync())
            {
                var memberFaker = new Faker<Member>()
                    .RuleFor(m => m.FullName, f => f.Name.FullName())
                    .RuleFor(m => m.Email, f => f.Internet.Email())
                    .RuleFor(m => m.Phone, f => f.Phone.PhoneNumber());

                var members = memberFaker.Generate(10);

                context.Members.AddRange(members);
                await context.SaveChangesAsync();
            }
        }
    }
}