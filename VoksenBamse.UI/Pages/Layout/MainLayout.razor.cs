using Microsoft.AspNetCore.Components;
using VoksenBamse.UI.Integration.Conversation;
using VoksenBamse.UI.ViewModel.Conversation;

namespace VoksenBamse.UI.Pages.Layout;

public partial class MainLayout
{
    [Inject]
    public IConversationLoader Loader { get; set; }

    private IReadOnlyCollection<BamseConversationInfoVmo>? _infos;

    protected override async Task OnParametersSetAsync()
    {
        _infos = await Loader.LoadInfos();
    }

}
