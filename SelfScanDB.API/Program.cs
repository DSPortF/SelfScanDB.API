using Microsoft.AspNetCore.Mvc;
using SelfScanDB.API.Data;

namespace SelfScanDB.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<IScannerDB, ScannerDB>();
        builder.Services.AddScoped<OracSync>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/OracSync", 
            ([FromServices] OracSync os) => os.ListAccounts());

        app.MapGet("/OracSync/{accountGuid}", 
            ([FromServices] OracSync os, string accountGuid) => os.ListAccountShops(accountGuid));

        app.MapGet("/OracSync/ShopDetails/{AccountGuid}/{ShopID}", 
            ([FromServices] OracSync os, string accountGuid, int ShopID) => os.ShopDetails(accountGuid, ShopID));

        app.MapGet("/OracSync/DeviceList/{AccountGuid}/{ShopID}", 
            ([FromServices] OracSync os, string accountGuid, int ShopID) => os.DeviceList(accountGuid, ShopID));

        // Takes a list of devices: "DeviceNames": ["DeviceA","DeviceB"] in the request body
        // Creates a new ticket on our internal system linking the ticket number with the relevant details.
        app.MapPost("/OracSync/NewTicket/{AccountGuid}/{ShopID}/{TicketID}",
            ([FromServices] OracSync os, string AccountGuid, int ShopID, int TicketID, [FromBody] List<string> DeviceNames) =>
            os.NewTicket(AccountGuid, ShopID, TicketID, DeviceNames));

        app.MapPost("/OracSync/UpdateTicket/{TicketID}/{NewStatus}",
            ([FromServices] OracSync os, int TicketID, string NewStatus) => os.UpdateTicket(TicketID, NewStatus));

        app.Run();
    }
}
