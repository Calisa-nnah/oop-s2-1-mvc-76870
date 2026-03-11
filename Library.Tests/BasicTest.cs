using Xunit;

namespace Library.Tests
{
    public class BasicTest
    {
        [Fact]
        public void AdditionTest()
        {
            int result = 2 + 3;
            Assert.Equal(5, result);
        }

        [Fact]
        public void StringContainsTest()
        {
            string title = "Clean Code";
            Assert.Contains("Code", title);
        }

        [Fact]
        public void BookAvailabilityTest()
        {
            bool isAvailable = true;
            Assert.True(isAvailable);
        }

        [Fact]
        public void LoanOverdueTest()
        {
            DateTime dueDate = DateTime.Today.AddDays(-2);
            bool overdue = dueDate < DateTime.Today;

            Assert.True(overdue);
        }

        [Fact]
        public void AdminRoleTest()
        {
            var roles = new List<string> { "Admin", "User" };
            bool isAdmin = roles.Contains("Admin");

            Assert.True(isAdmin);
        }
    }
}