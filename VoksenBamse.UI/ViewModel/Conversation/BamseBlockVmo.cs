namespace VoksenBamse.UI.ViewModel.Conversation;

public record BamseBlockVmo(
    BamseConversationalistVmo By,
    IReadOnlyCollection<BamseLineVmo> Lines
    )
{
    public bool IsRightSide => By.IsRightSide;
}
