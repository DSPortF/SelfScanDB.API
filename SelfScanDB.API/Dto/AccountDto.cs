using SelfScanDB.API.Data;

namespace SelfScanDB.API.Dto;

public class AccountDto
{
    public string AccountName { get; set; } = "";
    public string AccountGuid { get; set; } = "";

    public AccountDto(Account a)
    {
        AccountName = a.AccountName;
        AccountGuid = a.AccountGuid;
    }
}
