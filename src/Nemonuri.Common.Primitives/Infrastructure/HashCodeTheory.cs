namespace Nemonuri.Infrastructure;

public static class HashCodeTheory
{
    public static void AggregateHashCode<T, TCollection>(ref HashCode hashCode, TCollection items, IEqualityComparer<T>? equalityComparer)
        where TCollection : IEnumerable<T>
    {
        foreach (T item in items)
        {
            hashCode.Add(item, equalityComparer);
        }
    }
}