using SelfScanDB.API.Data;
using SelfScanDB.API.Dto;
using System.Security.Principal;

namespace SelfScanDB.API.Tests;

internal class TestDB : IScannerDB
{
    private List<Account> _accounts = new();
    private List<Shop> _shops = new List<Shop>();
    private List<Ticket> _tickets = new List<Ticket>();
    private List<TicketDeviceLink> _ticketDeviceLinks = new List<TicketDeviceLink>();

    public List<Ticket> Tickets => _tickets;
    public List<TicketDeviceLink> TicketDeviceLinks => _ticketDeviceLinks;

    public List<AccountDto> ListAccounts()
    {
        var ret = new List<AccountDto>();
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
        var ret = new List<Shop>();

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

    public ShopDto ShopDetails(string accountGuid, int shopID)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountGuid == accountGuid);
        if (account != null)
        {
            var shops = _shops.Where(s => s.AccountId == account.AccountId && s.ShopId == shopID).ToList();
            if (shops.Count > 0)
            {
                return new ShopDto(shops[0]);
            }
        }
        throw new KeyNotFoundException($"Shop with ID {shopID} not found for account {accountGuid}.");
    }

    public List<Device> DeviceList(string accountGuid, int shopID)
    {
        var account = _accounts.FirstOrDefault(a => a.AccountGuid == accountGuid);
        if (account != null)
        {
            var shops = _shops.Where(s => s.AccountId == account.AccountId && s.ShopId == shopID).ToList();
            if (shops.Count > 0)
            {
                return shops[0].Devices;
            }
        }
        throw new KeyNotFoundException($"Shop with ID {shopID} not found for account {accountGuid}.");
    }

    public void NewTicket(string accountGuid, int shopID, int ticketID, List<string> deviceNames)
    {
        // Add a new entry in the tickets list
        var account = _accounts.FirstOrDefault(a => a.AccountGuid == accountGuid);
        if (account == null)
            throw new KeyNotFoundException($"Account with GUID {accountGuid} not found.");

        var shops = _shops.Where(s => s.AccountId == account.AccountId && s.ShopId == shopID).ToList();
        if (shops.Count > 0)
        {
            var shop = shops[0];
            // Check if the ticket exists
            if (_tickets.Any(t => t.TicketId == ticketID))
            {
                throw new DuplicateKeyException($"Ticket with ID {ticketID} already exists.");
            }
            _tickets.Add(new Ticket(ticketID, "New", account.AccountId, shopID));
        }

        // For each device name, add a new entry to the ticket/device mapping
        int maxLinkId = _ticketDeviceLinks.Any() ? _ticketDeviceLinks.Max(tdl => tdl.LinkId) : 0;

        foreach (var deviceName in deviceNames)
        {
            _ticketDeviceLinks.Add(new TicketDeviceLink(++maxLinkId, ticketID, deviceName));
        }
    }

    public void UpdateTicket(int ticketId, string newStatus)
    {
        var ticket = _tickets.FirstOrDefault(t => t.TicketId == ticketId);
        if (ticket != null)
            ticket.TicketStatus = newStatus;
    }
}
