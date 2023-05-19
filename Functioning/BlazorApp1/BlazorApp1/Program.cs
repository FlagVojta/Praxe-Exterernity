using BlazorApp1.Authentication;
using BlazorApp1.Data;
using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using EntityFrameWorkDataAccess;
using EntityFrameworkLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;






var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUserData, UserData>();
builder.Services.AddTransient<IContractData, ContractData>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthentication>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddDbContextFactory<DemoDbContext>((DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));
builder.Services.AddTransient<DatabaseService>();
builder.Services.AddTransient<DemoDbContext>();
builder.Services.AddTransient<CustomNavigation>();
builder.Services.AddTransient<CustomAuthentication>();
builder.Services.AddSingleton<ExportService>();


var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjExNTg3MEAzMjMxMmUzMjJlMzNRektPalRzZVlLQjZTbXhkd0xRU2p3R0xtTzhUUFBqbS9ralo4cXBaRExRPQ==;Mgo+DSMBaFt+QHJqVk1lQ1NCaV1CX2BZdll3Q2laf04BCV5EYF5SRHNeS11rSHhQdkJkUXw=;Mgo+DSMBMAY9C3t2VFhiQlJPc0BAW3xLflF1VWtTflh6d1VWESFaRnZdQV1mSHdTfkRlWn9ZeXxW;Mgo+DSMBPh8sVXJ1S0R+X1pBaV1EQmFJfFBmTWlYeVRzdEU3HVdTRHRcQlhiQH5bd0NgWXdddXc=;MjExNTg3NEAzMjMxMmUzMjJlMzNXcTVOeGFLQkJxRndwb2pTMkNvdkVTU3dGYzhUQmVyZng4QURyRUUyZFdFPQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfVpdX2VWfFN0RnNRdV92flZGcC0sT3RfQF5jTH9adk1iX3xeeH1WRQ==;ORg4AjUWIQA/Gnt2VFhiQlJPc0BAW3xLflF1VWtTflh6d1VWESFaRnZdQV1mSHdTfkRlWn9XcXBW;MjExNTg3N0AzMjMxMmUzMjJlMzNDZWFwSmhPYlUrOUdhNW0wSnhOemt2TnVHR05HUVRDcnFTS3hkaHd6VjZrPQ==;MjExNTg3OEAzMjMxMmUzMjJlMzNabG1SVUluekRoYUZnT2JzRFRTb2ZWTjJ5aGN3TjRhVXlNR3BVS2ZLUTZBPQ==;MjExNTg3OUAzMjMxMmUzMjJlMzNrLy9pZVVwdUxuN0ZmR2p3dlJvaHZveTI5RjJHTVptaGhqMzkxMjZkd1FzPQ==;MjExNTg4MEAzMjMxMmUzMjJlMzNHaFVBM3lET0Q3QXJEYUNSUmoxSHhGZ2JNR3hXWG5vbXNqajJadlZsQ00wPQ==;MjExNTg4MUAzMjMxMmUzMjJlMzNRektPalRzZVlLQjZTbXhkd0xRU2p3R0xtTzhUUFBqbS9ralo4cXBaRExRPQ==");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
