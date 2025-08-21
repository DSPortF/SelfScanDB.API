namespace SelfScanDB.API.Data;

public class Account
{
    public int AccountId { get; set; }
    public string AccountName { get; set; } = "";
    public string AccountGuid { get; set; } = "";

    public Account(int accountId, string accountName, string accountGuid)
    {
        AccountId = accountId;
        AccountName = accountName;
        AccountGuid = accountGuid;
    }
}
