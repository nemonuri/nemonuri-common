namespace Nemonuri.Common.Primitives;

public static partial class ServiceProviderServiceExtensions
{
    public static T? GetService<TProvider, T>(this IServiceProvider serviceProvider)
        where TProvider : IProvider<T>
    {
        Guard.IsNotNull(serviceProvider);

        var provider = serviceProvider.GetService<TProvider>();
        if (provider == null) {return default(T);}

        var result = ((IProvider<T>)provider).Get();
        return result;
    }

    public static T GetRequiredService<TProvider, T>(this IServiceProvider serviceProvider)
        where TProvider : IProvider<T>
    {
        Guard.IsNotNull(serviceProvider);

        var provider = serviceProvider.GetService<TProvider>();
        if (provider == null) {return ThrowHelper.ThrowInvalidOperationException<T>();} //TODO: Error Message

        var result = ((IProvider<T>)provider).Get();
        if (result == null) {return ThrowHelper.ThrowInvalidOperationException<T>();} //TODO: Error Message

        return result;
    }
}