namespace Nemonuri.Infrastructure;

public class StructuralEqualityComparer<TItemList, TItem> : IEqualityComparer<TItemList>
    where TItemList : IReadOnlyList<TItem>
{
    private readonly static StructuralEqualityComparer<TItemList, TItem> s_default = new ();
    public static StructuralEqualityComparer<TItemList, TItem> Default => s_default;

    private readonly IEqualityComparer<TItem> _equalityComparer;

    public StructuralEqualityComparer(IEqualityComparer<TItem>? equalityComparer) 
    {
        _equalityComparer = equalityComparer ?? EqualityComparer<TItem>.Default;
    }

    public StructuralEqualityComparer() : this(null)
    {}

    public bool Equals(TItemList? x, TItemList? y)
    {
        if (x == null || y == null) {return false;}

        if (x.Count != y.Count) {return false;}

        int i=0;
        foreach (TItem item in x)
        {
            bool isEqual = _equalityComparer.Equals(item, y[i]);
            if (!isEqual) {return false;}
            i++;
        }

        return true;
    }

    public int GetHashCode([DisallowNull] TItemList obj)
    {
        HashCode hashCode = new ();
        hashCode = obj.Aggregate(hashCode, (gseed, item) => {
            gseed.Add(item, _equalityComparer);
            return gseed;
        });
        return hashCode.ToHashCode();
    }
}
