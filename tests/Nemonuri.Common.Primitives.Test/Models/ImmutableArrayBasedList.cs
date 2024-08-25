namespace Nemonuri.Common.Primitives.Test.Models;

public readonly partial struct ImmutableArrayBasedList<T> : IReadOnlyList<T>, IEquatable<ImmutableArrayBasedList<T>>
{
    private readonly ImmutableArray<T> _array;

    public ImmutableArrayBasedList(IEnumerable<T>? values = null)
    {
        _array = values?.ToImmutableArray() ?? [];
    }

    public bool IsDefault => _array.IsDefault;

    public T this[int index] => _array[index];

    public int Count => _array.Length;

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _array)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Equals(ImmutableArrayBasedList<T> other) =>
        StructuralEqualityComparer<ImmutableArray<T>, T>.Default.Equals(_array, other._array);

    public override bool Equals(object? obj) =>
        obj is ImmutableArrayBasedList<T> v && Equals(v);
    
    public override int GetHashCode() =>
        StructuralEqualityComparer<ImmutableArray<T>, T>.Default.GetHashCode(_array);

    public static bool operator ==(ImmutableArrayBasedList<T> left, ImmutableArrayBasedList<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ImmutableArrayBasedList<T> left, ImmutableArrayBasedList<T> right)
    {
        return !(left == right);
    }

    public override string ToString() =>
        ListToStringMapping<ImmutableArray<T>, T>.Default.Map(_array);
}