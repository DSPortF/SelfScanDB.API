using SelfScanDB.API.Data;

namespace SelfScanDB.API.Dto;

public class ShopDto
{
    public int ShopId { get; set; }
    public string ShopName { get; set; } = "";
    public string ShopAddress { get; set; } = "";
    public int AccountId { get; set; } = 0;
    public List<string> DeviceNames { get; set; } = new List<string>();

    public ShopDto(Shop s)
    {
        ShopId = s.ShopId;
        ShopName = s.ShopName;
        ShopAddress = s.ShopAddress;
        AccountId = s.AccountId;
        DeviceNames = s.Devices.Select(d => d.DeviceName).ToList();
    }
}
