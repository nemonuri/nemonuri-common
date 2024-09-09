namespace Nemonuri.Infrastructure;

public static class ReceiverPolyfill
{
    public static void PolyfillOnReceived<T>
    (
        IReceiver<T> source,
        object? provider, object? received,
        Action<object?, object?>? fallback = null
    )
    {
        Guard.IsNotNull(source);

        if (received is T vT)
        {
            source.OnReceived(provider, vT);
        }
        else if (received is null)
        {
            source.OnReceived(provider, default(T));
        }
        else if (fallback != null)
        {
            fallback(provider, received);
        }
        else
        {
            throw new InvalidOperationException
            (
                string.Format
                (
                    "Type mismatched. expected: {0}, actual: {1}", 
                    typeof(T),
                    received.GetType()
                )
            );
        }
    }
}