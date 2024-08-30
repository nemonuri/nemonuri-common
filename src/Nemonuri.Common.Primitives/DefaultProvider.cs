namespace Nemonuri.Common.Primitives;

public class DefaultProvider<T> : IProvider<T>
{
    private readonly T _value;

    public DefaultProvider(T value)
    {
        _value = value;
    }

    public T Get() => _value;
}