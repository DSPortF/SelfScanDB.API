namespace SelfScanDB.API.Data
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketStatus { get; set; } = "";
        public int AccountId { get; set; }
        public int ShopId { get; set; }
        public Ticket(int ticketId, string ticketStatus, int accountId, int shopId)
        {
            TicketId = ticketId;
            TicketStatus = ticketStatus;
            AccountId = accountId;
            ShopId = shopId;
        }
    }
}
