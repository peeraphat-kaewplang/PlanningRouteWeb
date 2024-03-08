using PlanningRouteWeb.Components;
using PlanningRouteWeb.HttpHandlers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Services;
using PlanningRouteWeb.Services.V2;
using Radzen;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(x => x.DetailedErrors = true);
builder.Services.AddRadzenComponents();
builder.Services.AddControllers();
builder.Services.AddLocalization();

builder.Services.AddScoped(
   sp => new HttpClient(new CustomHeaderHandler(builder.Configuration)) { BaseAddress = new Uri(builder.Configuration.GetValue<string>("Configs:UrlApi")!) });

builder.Services.AddScoped<IPlanningService, PlanningService>();
builder.Services.AddScoped<IChangeProductService, ChangeProductService>();
builder.Services.AddScoped<IDialogService, DialogServices>();
builder.Services.AddScoped<IBestProduct, BestProductService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ITimelineService, TimelineService>();
builder.Services.AddScoped<ISetDatetimeService, SetDatetimeService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<StateContainer>();

builder.Services.AddMvc().AddJsonOptions(options => {
    options.JsonSerializerOptions.MaxDepth = 10000;  // or however deep you need
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Verify}/{action=Index}/{id?}");

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
