namespace SelfScanDB.API.Data;

public class Device
{
    // "Device1", "DevType - Test", DateTime.Now, "xyz123a"
    public string DeviceName { get; set; } = "";
    public string DeviceType { get; set; } = "";
    public DateTime LastContact { get; set; }
    public string DeviceSerial { get; set; } = "";
    
    public Device(string deviceName, string deviceType, DateTime lastContact, string deviceSerial)
    {
        DeviceName = deviceName;
        DeviceType = deviceType;
        LastContact = lastContact;
        DeviceSerial = deviceSerial;
    }
}
