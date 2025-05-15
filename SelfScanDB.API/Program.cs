
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

        app.MapGet("/OracSync", ([FromServices] OracSync os) => os.ListAccounts())
            .WithName("GetOracSync");

        app.Run();
    }
}
