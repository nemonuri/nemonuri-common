namespace Nemonuri.Infrastructure;

public class StructuralEqualityComparer<TItemList, TItem> : IEqualityComparer<TItemList>
    where TItemList : IReadOnlyList<TItem>
{
    private readonly static StructuralEqualityComparer<TItemList, TItem> s_default = new ();
    public static StructuralEqualityComparer<TItemList, TItem> Default => s_default;

    public StructuralEqualityComparer() {}

    public bool Equals(TItemList? x, TItemList? y)
    {
        if (x == null || y == null) {return false;}

        if (x.Count != y.Count) {return false;}

        int i=0;
        foreach (TItem item in x)
        {
            bool isEqual = item?.Equals(y[i]) ?? false;
            if (!isEqual) {return false;}
            i++;
        }

        return true;
    }

    public int GetHashCode([DisallowNull] TItemList obj)
    {
        HashCode hashCode = new ();
        hashCode = obj.Aggregate(hashCode, (gseed, item) => {
            gseed.Add(item);
            return gseed;
        });
        return hashCode.ToHashCode();
    }
}
