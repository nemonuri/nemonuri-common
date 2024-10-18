using System.Collections;

namespace Nemonuri;

public interface ICollectionProvider
{
    IEnumerable GetCollection();
}

public interface ICollectionProvider<T> : ICollectionProvider
{
    new IEnumerable<T> GetCollection();
}