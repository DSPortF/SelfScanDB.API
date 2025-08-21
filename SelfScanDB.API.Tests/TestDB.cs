using SelfScanDB.API.Data;
using SelfScanDB.API.Dto;
using System.Security.Principal;

namespace SelfScanDB.API.Tests;

internal class TestDB : IScannerDB
{
    private List<Account> _accounts = new();
    private List<Shop> _shops = new List<Shop>();

    public List<AccountDto> ListAccounts()
    {
        var ret= new List<AccountDto>();
        foreach (var acc in _accounts)
        {
            ret.Add(new AccountDto(acc));
        }
        return ret;
    }

    public void AddAccount(int accountId, string accountName, string accountGuid)
    {
        _accounts.Add(new Account(accountId, accountName, accountGuid));
    }

    public List<Shop> ListAccountShops(string accountGuid)
    {
        var ret=new List<Shop>();

        var account = _accounts.FirstOrDefault(a => a.AccountGuid == accountGuid);
        if (account == null)
            return ret;

        var shops = _shops.Where(s => s.AccountId == account.AccountId).ToList();
        return shops;
    }

    public void AddShop(Shop s)
    {
        _shops.Add(s);
    }

    public Shop ShopDetails(string accountGuid, int shopID)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountGuid == accountGuid);
        if (account != null)
        {
            var shops = _shops.Where(s => s.AccountId == account.AccountId && s.ShopId == shopID).ToList();
            if (shops.Count > 0)
            {
                return shops[0];
            }
        }
        throw new KeyNotFoundException($"Shop with ID {shopID} not found for account {accountGuid}.");
    }
}
