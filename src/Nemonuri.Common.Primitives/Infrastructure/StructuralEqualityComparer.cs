namespace Nemonuri.Infrastructure;

public class StructuralEqualityComparer<T, TList> : IEqualityComparer<TList>
    where TList : IReadOnlyList<T>
{
    private readonly IEqualityComparer<T>? _innerEqualityComparer;

    public StructuralEqualityComparer(IEqualityComparer<T>? innerEqualityComparer = null) 
    {
        _innerEqualityComparer = innerEqualityComparer;
    }

    public IEqualityComparer<T>? InnerEqualityComparer => _innerEqualityComparer;

    public bool Equals(TList? left, TList? right) => StructuralEqualityTheory.StructuralEquals(left, right, _innerEqualityComparer);

    public int GetHashCode([DisallowNull] TList obj)
    {
        HashCode hashCode = new ();
        StructuralEqualityTheory.AggregateHashCode(ref hashCode, obj, _innerEqualityComparer);
        return hashCode.ToHashCode();
    }
}