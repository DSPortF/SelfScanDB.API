namespace SelfScanDB.API.Tests
{
    public class OracSyncTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_HelloWorld()
        {
            var sut = new OracSync();
            string expected = "Hello world";
            string actual = sut.HelloWorld();
            
            // Updated to use Assert.That with Is.EqualTo constraint
            Assert.That(actual, Is.EqualTo(expected), "Function should have returned 'Hello World'");
        }
    }
}
