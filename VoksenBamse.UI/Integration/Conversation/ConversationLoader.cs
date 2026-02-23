using VoksenBamse.UI.Util;
using VoksenBamse.UI.ViewModel.Conversation;

namespace VoksenBamse.UI.Integration.Conversation;


public interface IConversationLoader
{
    Task<IReadOnlyCollection<BamseConversationInfoVmo>> LoadInfos();
    Task<BamseConversationVmo?> LoadConversation(string id);
}

public class ConversationLoader : IConversationLoader
{
    private static readonly BamseConversationalistVmo Me = new BamseConversationalistVmo("me", "Me", IsRightSide: true);
    private static readonly BamseConversationalistVmo They = new BamseConversationalistVmo("they", "They", IsRightSide: false);

    private IReadOnlyCollection<BamseConversationVmo>? _conversations;
    private IReadOnlyCollection<BamseConversationVmo> Conversations => _conversations ??= MakeDummies();
    public async Task<BamseConversationVmo?> LoadConversation(string id)
    {
        await Task.CompletedTask;
        var returnee = Conversations
            .FirstOrDefault(_ => _.Id == id);
        returnee ??= Conversations.First();
        return returnee;
    }

    public async Task<IReadOnlyCollection<BamseConversationInfoVmo>> LoadInfos()
    {
        await Task.CompletedTask;
        var returnee = Conversations
            .Select(_ => _.ToInfo())
            .ToReadOnly();
        return returnee;
    }

    public IReadOnlyCollection<BamseConversationVmo> MakeDummies() => Enumerable.Range(0, 20)
            .Select(indx => $"Conversation: {indx}")
            .Select(nam => new BamseConversationVmo(
                Id: nam
                        .Replace(":", "")
                        .Replace(" ", ""),
                Name: nam,
                Blocks: Enumerable.Range(0, 7)
                    .SelectMany(blockNo => new List<BamseBlockVmo>
                    {
                        new BamseBlockVmo(
                            They,
                            Lines: Enumerable.Range(0,2)
                                .Select(linNo => new BamseLineVmo(Text: "Jeg siger og hvad så og hvad så lo lo lo lo lo kan man måske få noget betjening her?"))
                                .ToReadOnly()
                         ),
                        new BamseBlockVmo(
                            Me,
                            Lines: Enumerable.Range(0,2)
                                .Select(linNo => new BamseLineVmo(Text: "Næh, det tror jeg godt nok ikke lige du sagde tro lol lol"))
                                .ToReadOnly()
                         ),

                    }).ToReadOnly()
                )
            ).ToList();


}
