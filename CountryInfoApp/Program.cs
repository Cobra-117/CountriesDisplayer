using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using MudBlazor.Services;




var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddMudBlazorJsEvent();




builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        options.EnableDetailedErrors = true;
        options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    });
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