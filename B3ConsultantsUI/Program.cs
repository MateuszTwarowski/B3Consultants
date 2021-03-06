using B3ConsultantsUI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IConsultantService, ConsultantService>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7273/");
    });
builder.Services.AddHttpClient<IRoleService, RoleService>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7273/");
    });
builder.Services.AddHttpClient<IExperienceService, ExperienceService>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7273/");
    });
builder.Services.AddHttpClient<IAvailabilityService, AvailabilityService>(
    client =>
    {
        client.BaseAddress = new Uri("https://localhost:7273/");
    });

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

app.UseStaticFiles();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
