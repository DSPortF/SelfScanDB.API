using SelfScanDB.API.Data;
using SelfScanDB.API.Dto;

namespace SelfScanDB.API;

public class OracSync
{
    private readonly IScannerDB _db;

    public OracSync(IScannerDB db)
    {
        _db = db;
    }

    public List<AccountDto> ListAccounts()
    {
        return _db.ListAccounts();
    }

    public List<Shop> ListAccountShops(string accountGuid)
    {
        return _db.ListAccountShops(accountGuid);
    }

    public Shop ShopDetails(string accountGuid, int shopID)
    {
        return _db.ShopDetails(accountGuid, shopID);
    }
}
