using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AVA.VendorService;
public class Program {
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    /*public static async Task<int> Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(DefaultCorsPolicyName, builder =>
            {
                //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                builder
                    .WithOrigins(new string[] { "http://localhost:57310", "https://localhost:44322", "https://localhost:44342" })
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Vendor Service API",
                Description = "Vendor service API"                
            });
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(DefaultCorsPolicyName); //Enable CORS!
        app.UseSwagger();
       
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendors Service API");
            c.RoutePrefix = String.Empty;
        });

        await app.RunAsync();
        return 0;
    }*/

}