namespace SelfScanDB.API.Data;

public class Shop
{
    public int ShopId { get; set; }
    public string ShopName { get; set; } = "";
    public string ShopAddress { get; set; } = "";
    public int AccountId { get; set; } = 0;

    public List<Device> Devices { get; set; } = new List<Device>();

    public Shop(int shopId, string shopName, string shopAddress, int accountId)
    {
        ShopId = shopId;
        ShopName = shopName;
        ShopAddress = shopAddress;
        AccountId = accountId;
    }

    public void AddDevice(Device device)
    {
        Devices.Add(device);
    }
}
