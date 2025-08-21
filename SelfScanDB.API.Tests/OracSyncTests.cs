using SelfScanDB.API.Data;

namespace SelfScanDB.API.Tests
{
    public class OracSyncTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ListAccount_ShouldReturnAccounts()
        {
            // Create test DB
            var testDB = new TestDB();
            testDB.AddAccount(1, "Old Look", "12345678-1234-1234-1234-123456789012");
            testDB.AddAccount(2, "Maljanvier", "87654321-4321-4321-4321-210987654321");

            // Add first account name and GUID
            // Add second account name and GUID
            var sut = new OracSync(testDB);
            var result = sut.ListAccounts();
            Assert.That(result, Has.Exactly(2).Items, "ListAccounts should return 2 accounts");
        }

        [Test]
        public void ListAccountShops_ShouldReturnAccountShops()
        {
            var testDB = new TestDB();
            testDB.AddAccount(1, "Tertiark", "12345678-1234-1234-1234-123456789012");
            var testDev = new Device("Device1", "DevType - Test", DateTime.Now, "xyz123a");
            var testShop = new Shop(51, "Tertiark - Macclesfield", "427 Castle Street, Macclesfield, Cheshire, SK11 6XX", 1);
            testShop.AddDevice(testDev);
            testDB.AddShop(testShop);

            var sut = new OracSync(testDB);
            var result = sut.ListAccountShops("12345678-1234-1234-1234-123456789012");
            Assert.That(result, Has.Exactly(1).Items, "ListAccountShops should return 1 shop");
        }

        [Test]
        public void ShopDetails_ShouldReturnShopDetails()
        {
            var testDB = new TestDB();
            testDB.AddAccount(1, "Tertiark", "12345678-1234-1234-1234-123456789012");
            var testDev = new Device("Device1", "DevType - Test", DateTime.Now, "xyz123a");
            var testShop = new Shop(51, "Tertiark - Macclesfield", "427 Castle Street, Macclesfield, Cheshire, SK11 6XX", 1);
            testShop.AddDevice(testDev);
            testDB.AddShop(testShop);

            var sut = new OracSync(testDB);
            var result = sut.ShopDetails("12345678-1234-1234-1234-123456789012", 51);
            Assert.That(result, Is.Not.Null, "ShopDetails should return a shop");
            Assert.That(result.ShopId, Is.EqualTo(51), "ShopDetails should return the correct shop ID");
        }

        [Test]
        public void ShopDetails_ShouldThrowIfNoSuchShop()
        {
            var testDB = new TestDB();
            testDB.AddAccount(1, "Tertiark", "12345678-1234-1234-1234-123456789012");
            var testDev = new Device("Device1", "DevType - Test", DateTime.Now, "xyz123a");
            var testShop = new Shop(51, "Tertiark - Macclesfield", "427 Castle Street, Macclesfield, Cheshire, SK11 6XX", 1);
            testShop.AddDevice(testDev);
            testDB.AddShop(testShop);

            var sut = new OracSync(testDB);
            // Test with a non-existing shop ID
            Assert.Throws<KeyNotFoundException>(() => 
                sut.ShopDetails("12345678-1234-1234-1234-123456789012", 999), 
                "ShopDetails should throw KeyNotFoundException for non-existing shop ID");
        }
    }
}
