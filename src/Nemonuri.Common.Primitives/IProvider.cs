namespace Nemonuri.Common.Primitives;

public interface IProvider<T>
{
    T Get();
}
