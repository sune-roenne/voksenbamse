namespace VoksenBamse.UI.ViewModel.Conversation;

public record BamseConversationVmo(
    string Id,
    string Name,
    IReadOnlyCollection<BamseBlockVmo> Blocks
    )
{
}

public record BamseConversationInfoVmo(
    string Id,
    string Name
    )
{

}
