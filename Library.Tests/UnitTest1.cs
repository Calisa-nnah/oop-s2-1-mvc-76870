namespace Library.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ThsTestShouldFail()
        {
            string name = "John";
            Assert.Equal("Jane", name);


        }
    }
}