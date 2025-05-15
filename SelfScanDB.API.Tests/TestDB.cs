using SelfScanDB.API.Data;
using SelfScanDB.API.Dto;

namespace SelfScanDB.API.Tests;

internal class TestDB : IScannerDB
{
    private List<AccountDto> _accounts = new List<AccountDto>();

    public List<AccountDto> ListAccounts()
    {
        return _accounts;
    }

    public void AddAccount(string AccountName, string AccountGuid)
    {
        _accounts.Add(new AccountDto
        {
            AccountName = AccountName,
            AccountGuid = AccountGuid
        });
    }
}
