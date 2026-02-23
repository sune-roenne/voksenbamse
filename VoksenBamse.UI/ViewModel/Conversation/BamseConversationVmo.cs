namespace VoksenBamse.UI.ViewModel.Conversation;

public record BamseConversationVmo(
    string Id,
    string Name,
    IReadOnlyCollection<BamseBlockVmo> Blocks
    )
{
    public BamseConversationInfoVmo ToInfo() => new BamseConversationInfoVmo(Id, Name);

}

public record BamseConversationInfoVmo(
    string Id,
    string Name
    )
{

}
