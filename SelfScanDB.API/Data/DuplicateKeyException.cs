namespace SelfScanDB.API.Data;

public class DuplicateKeyException : Exception
{
    public DuplicateKeyException(string? message) : base(message)
    {
    }
}
