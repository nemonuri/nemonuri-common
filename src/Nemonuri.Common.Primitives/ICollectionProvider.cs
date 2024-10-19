using System.Collections;

namespace Nemonuri;

public interface ICollectionProvider<T> : IServiceProvider
{
    IEnumerable<T> GetCollection();
}