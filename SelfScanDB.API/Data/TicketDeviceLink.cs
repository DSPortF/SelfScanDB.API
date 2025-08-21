namespace SelfScanDB.API.Data
{
    public class TicketDeviceLink
    {
        public int LinkId { get; set; }
        public int TicketId { get; set; }
        public string DeviceName { get; set; } = "";
        public TicketDeviceLink(int linkId, int ticketId, string deviceName)
        {
            LinkId = linkId;
            TicketId = ticketId;
            DeviceName = deviceName;
        }
    }
}
