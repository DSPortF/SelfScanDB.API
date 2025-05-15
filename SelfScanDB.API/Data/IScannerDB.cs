using SelfScanDB.API.Dto;

namespace SelfScanDB.API.Data;

public interface IScannerDB
{
    List<AccountDto> ListAccounts();
}