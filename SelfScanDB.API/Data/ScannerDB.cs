using SelfScanDB.API.Dto;

namespace SelfScanDB.API.Data;

public class ScannerDB : IScannerDB
{
    public List<Device> DeviceList(string accountGuid, int shopID)
    {
        throw new NotImplementedException();
    }

    public List<AccountDto> ListAccounts()
    {
        throw new NotImplementedException();
    }

    public List<Shop> ListAccountShops(string accountGuid)
    {
        throw new NotImplementedException();
    }

    public void NewTicket(string accountGuid, int shopID, int ticketID, List<string> deviceNames)
    {
        throw new NotImplementedException();
    }

    public ShopDto ShopDetails(string accountGuid, int shopID)
    {
        throw new NotImplementedException();
    }

    public void UpdateTicket(int ticketId, string newStatus)
    {
        throw new NotImplementedException();
    }
}
