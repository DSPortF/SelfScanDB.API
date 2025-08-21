using SelfScanDB.API.Data;
using SelfScanDB.API.Dto;

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
}
