namespace Nemonuri.Primitives;

public class ListToStringMapping<TItemList, TItem> where TItemList : IReadOnlyList<TItem>
{
    private readonly static ListToStringMapping<TItemList, TItem> s_default = new ();

    public static ListToStringMapping<TItemList, TItem> Default => s_default;


    private const string DefaultDelimiter = ",";

    private readonly string _delimiter;

    public string Delimiter => _delimiter;

    public ListToStringMapping() : this(delimiter:null)
    {}

    public ListToStringMapping(string? delimiter = null)
    {
        _delimiter = delimiter ?? DefaultDelimiter;
    }

    public string Map(TItemList source)
    {
        Guard.IsNotNull(source);

        StringBuilder sb = new StringBuilder();
        sb.Append('[');

        bool looped = false;
        foreach (TItem item in source)
        {
            if (looped) {sb.Append(_delimiter);}

            sb.Append(item?.ToString());
            looped = true;
        }

        sb.Append(']');

        return sb.ToString();
    }
}