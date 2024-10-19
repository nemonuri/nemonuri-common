namespace Nemonuri;

public interface IProvider<T> : IServiceProvider
{
    T? Get();
}
