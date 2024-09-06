namespace Nemonuri;

public class DefaultProvider<T> : IProvider<T>
{
    private readonly T _value;

    public DefaultProvider(T value)
    {
        _value = value;
    }

    public T Get() => _value;

    object IProvider.Get() => Get()!;
}