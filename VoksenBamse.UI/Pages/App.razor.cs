using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using VoksenBamse.UI.Configuration;

namespace VoksenBamse.UI.Pages;

public partial class App
{
    [Inject]
    public IOptions<ConfigurationUI> UiConfig { get; set; }
    private string AppBase => string.IsNullOrWhiteSpace(UiConfig.Value.BasePath) ? "/" : $"/{UiConfig.Value.BasePath}/";

}
