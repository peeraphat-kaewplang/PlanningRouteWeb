using PlanningRouteWeb.HttpHandlers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(x => x.DetailedErrors = true);
builder.Services.AddRadzenComponents();
builder.Services.AddLocalization();

builder.Services.AddScoped(
   sp => new HttpClient(new CustomHeaderHandler(builder.Configuration)) { BaseAddress = new Uri(builder.Configuration.GetValue<string>("Configs:UrlApi")!) });

builder.Services.AddScoped<IPlanningService , PlanningService>();
builder.Services.AddScoped<IChangeProductService, ChangeProductService>();
builder.Services.AddScoped<IDialogService, DialogServices>();
builder.Services.AddScoped<StateContainer>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRequestLocalization("en-US");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
