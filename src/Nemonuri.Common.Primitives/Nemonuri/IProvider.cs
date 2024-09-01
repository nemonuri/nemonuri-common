namespace Nemonuri;

public interface IProvider<T>
{
    T Get();
}
