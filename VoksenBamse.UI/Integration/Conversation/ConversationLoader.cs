using VoksenBamse.UI.ViewModel.Conversation;

namespace VoksenBamse.UI.Integration.Conversation;


public interface IConversationLoader
{
    Task<IReadOnlyCollection<BamseConversationInfoVmo>> LoadInfos();
    Task<BamseConversationVmo?> LoadConversation(string id);
}

public class ConversationLoader
{
}
