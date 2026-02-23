namespace VoksenBamse.UI.Util;

public static class CollectionExtensions
{
    public static IReadOnlyCollection<TEnt> ToReadOnly<TEnt>(this IEnumerable<TEnt> inp) => inp.ToList();


}
