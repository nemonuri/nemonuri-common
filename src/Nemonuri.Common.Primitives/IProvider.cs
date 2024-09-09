namespace Nemonuri;

public interface IProvider
{
    object? Get();
}

public interface IProvider<T> : IProvider
{
    new T? Get();
}
