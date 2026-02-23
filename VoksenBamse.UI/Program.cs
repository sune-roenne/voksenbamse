
using VoksenBamse.UI;
using VoksenBamse.UI.Configuration;
using VoksenBamse.UI.Pages;

var builder = WebApplication.CreateBuilder(args);
builder.AddBamseConfiguration();
var uiConf = new ConfigurationUI();
builder.Configuration.GetSection(ConfigurationUI.ElementName)
    .Bind(uiConf);
builder.Services.Configure<ConfigurationUI>(builder.Configuration.GetSection(ConfigurationUI.ElementName));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.AddBamseServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

if (!string.IsNullOrEmpty(uiConf.BasePath))
    app.MapBlazorHub("/" + uiConf.BasePath)
    .WithOrder(-1);



app.Run();
