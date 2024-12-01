namespace Nemonuri.Infrastructure;

public static class StructuralEqualityTheory
{
    public static bool StructuralEquals<T, TList>(TList? left, TList? right, IEqualityComparer<T>? equalityComparer = null)
        where TList : IReadOnlyList<T>
    {
        if (left == null || right == null) {return false;}

        if (left.Count != right.Count) {return false;}

        int i=0;
        if (equalityComparer is not null)
        {
            foreach (T item in left)
            {
                bool isEqual = equalityComparer.Equals(item, right[i]);
                if (!isEqual) {return false;}
                i++;
            }
        }
        else
        {
            foreach (T item in left)
            {
                if 
                (
                    !(item is { } item1) ||
                    !(right[i] is { } item2)
                ) 
                {
                    return false;
                }

                if (!item1.Equals(item2)) {return false;}
                i++;
            }
        }

        return true;
    }

    public static void AggregateHashCode<T, TCollection>(ref HashCode hashCode, TCollection items, IEqualityComparer<T>? equalityComparer = null)
        where TCollection : IEnumerable<T>
    {
        Guard.IsNotNull(items);

        foreach (T item in items)
        {
            hashCode.Add(item, equalityComparer);
        }
    }
}