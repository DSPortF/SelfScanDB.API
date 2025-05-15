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
            var testDB = new TestDB();

            var sut = new OracSync(testDB);
            string expected = "Hello World";
            string actual = sut.HelloWorld();
            
            // Updated to use Assert.That with Is.EqualTo constraint
            Assert.That(actual, Is.EqualTo(expected), "Function should have returned 'Hello World'");
        }

        [Test]
        public void ListAccount_ShouldReturnAccounts()
        {
            // Create test DB
            var testDB = new TestDB();
            testDB.AddAccount("Old Look", "12345678-1234-1234-1234-123456789012");
            testDB.AddAccount("Majlanvier", "87654321-4321-4321-4321-210987654321");

            // Add first account name and GUID
            // Add second account name and GUID
            var sut = new OracSync(testDB);
            var result = sut.ListAccounts();
            Assert.That(result, Has.Exactly(2).Items, "ListAccounts should return 2 accounts");
        }
    }
}
