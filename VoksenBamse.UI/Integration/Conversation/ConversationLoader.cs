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
    private IReadOnlyCollection<BamseConversationVmo> Conversations => _conversations ??= [ConvoSicnkess];
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

    private static BamseConversationVmo? _convoSickness;
    private static BamseConversationVmo ConvoSicnkess => _convoSickness ??= new BamseConversationVmo(
        Id: "sick",
        Name: "Sygdom i Bamsehulen",
        Blocks: [
            BThey("Hvordan går det hjemme i Bamsehulen? 🙂"),
            BMe("Jeg har det simpelthen så dårligt... jeg sidder på toilettet hvert 5. minut! Hvornår kommer du hjem?"),
            BThey(
                    "Yikes! Lyder ubehageligt! 🤢", 
                    "Tror du ikke du kan få din mor til at komme forbi? Kampen starter kl. 20",
                    "Jeg kan skrive til Marianne på dine vegne?"),
            BMe("Min mor er til banko", "og nej... det er ikke Mariannes opgave (!)"),
            BThey("Jeg er sikker på hun godt vil give en hånd med 🙂"),
            BMe("Glem det"),
            BThey("Vi behøver ikke at skulle klare alle vores problemer selv. I den her situation kan man godt forvente lidt hjælp fra sine venner..."),
            BMe("Eller éns kæreste som er til fodboldkamp...?", "Jeg har aldrig været så syg som nu!"),
            BThey("Jeg kan gå i halvlegen", "I mellemtiden smider du bare Olivia [3 år] og Oscar [1 år] i hver deres badekar og så kan du sidde på toillettet imens 👍")

            ]

        );


    private static BamseBlockVmo BMe(params IEnumerable<string> texts) => B(Me, texts);
    private static BamseBlockVmo BThey(params IEnumerable<string> texts) => B(They, texts);

    private static BamseBlockVmo B(BamseConversationalistVmo person, params IEnumerable<string> texts) => new BamseBlockVmo(
        By: person,
        texts
            .Select(tex => new BamseLineVmo(tex))
            .ToReadOnly()
        );


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
