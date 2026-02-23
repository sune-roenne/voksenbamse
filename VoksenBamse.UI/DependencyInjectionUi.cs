using VoksenBamse.UI.Configuration;
using VoksenBamse.UI.Integration.Conversation;

namespace VoksenBamse.UI;

public static class DependencyInjectionUi
{
    public static WebApplicationBuilder AddBamseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false);
        builder.Configuration.AddJsonFile("appsettings.local.json", optional: true);
        return builder;
    }

    public static WebApplicationBuilder AddBamseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IConversationLoader, ConversationLoader>();
        return builder;
    }


}
