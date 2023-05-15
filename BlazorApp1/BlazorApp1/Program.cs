using BlazorApp1.Authentication;
using BlazorApp1.Data;
using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using EntityFrameWorkDataAccess;
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

var app = builder.Build();

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
