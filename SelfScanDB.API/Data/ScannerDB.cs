using SelfScanDB.API.Dto;

namespace SelfScanDB.API.Data;

public class ScannerDB : IScannerDB
{
    public List<AccountDto> ListAccounts()
    {
        throw new NotImplementedException();
    }

    public List<Shop> ListAccountShops(string accountGuid)
    {
        throw new NotImplementedException();
    }

    public Shop ShopDetails(string accountGuid, int shopID)
    {
        throw new NotImplementedException();
    }
}
