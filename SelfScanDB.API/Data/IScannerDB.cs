using SelfScanDB.API.Dto;

namespace SelfScanDB.API.Data;

public interface IScannerDB
{
    List<Device> DeviceList(string accountGuid, int shopID);
    List<AccountDto> ListAccounts();
    List<Shop> ListAccountShops(string accountGuid);
    void NewTicket(string accountGuid, int shopID, int ticketID, List<string> deviceNames);
    ShopDto ShopDetails(string accountGuid, int shopID);
    void UpdateTicket(int ticketId, string newStatus);
}
