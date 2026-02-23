using Microsoft.AspNetCore.Components;
using VoksenBamse.UI.Integration.Conversation;
using VoksenBamse.UI.ViewModel.Conversation;

namespace VoksenBamse.UI.Pages;

public partial class ConversationPage
{
    [Parameter]
    public string ConversationId { get; set; }

    [Inject]
    public IConversationLoader Loader { get; set; }

    private BamseConversationVmo? _conversation;

    protected override async Task OnParametersSetAsync()
    {
        if(!string.IsNullOrWhiteSpace(ConversationId))
        {
            _conversation ??= await Loader.LoadConversation(ConversationId);
        }
    }

}
