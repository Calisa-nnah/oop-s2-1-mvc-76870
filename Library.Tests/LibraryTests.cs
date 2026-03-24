using System;
using System.Collections.Generic;
using Xunit;

namespace Library.Tests
{
    
    /// Basic unit tests to validate simple behaviors used while developing the library sample.
    /// These are lightweight sanity checks, not exhaustive domain tests.
   
    public class LibraryTests
    {
      
        /// Simple arithmetic test to ensure test project is running and assertions work.
        /// Verifies that 2 + 3 equals 5.
      
        [Fact]
        public void AdditionTest()
        {
            int result = 2 + 3;
            Assert.Equal(5, result);
        }

        
        /// String containment test.
        /// Ensures the sample title contains the substring "Code".
        
        [Fact]
        public void StringContainsTest()
        {
            string title = "Clean Code";
            Assert.Contains("Code", title);
        }

        /// Placeholder availability test for a Book entity.
        /// In a real test this would check a Book.IsAvailable property after setup.
      
        [Fact]
        public void BookAvailabilityTest()
        {
            bool isAvailable = true;
            Assert.True(isAvailable);
        }

        /// Overdue loan check: ensures a date two days in the past is considered overdue.
        /// Demonstrates date comparison assertions.
        [Fact]
        public void LoanOverdueTest()
        {
            DateTime dueDate = DateTime.Today.AddDays(-2);
            bool overdue = dueDate < DateTime.Today;

            Assert.True(overdue);
        }

        /// Role membership test (example).
        /// In a real scenario this would query the role store or a user's claims.
        [Fact]
        public void AdminRoleTest()
        {
            var roles = new List<string> { "Admin", "User" };
            bool isAdmin = roles.Contains("Admin");

            Assert.True(isAdmin);
        }
    }
}