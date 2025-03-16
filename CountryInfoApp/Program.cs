using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();



builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<CountryService>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();
app.UseStaticFiles();



app.UseRouting();

// Ensure authorization middleware is added if needed
app.UseAuthorization();

// Map Razor Pages (for MVC-based pages like _Host.cshtml)
app.MapRazorPages();

// Map Blazor Server components
app.MapBlazorHub();

// Map fallback to _Host page for Blazor Server
app.MapFallbackToPage("/_Host");

app.Run();