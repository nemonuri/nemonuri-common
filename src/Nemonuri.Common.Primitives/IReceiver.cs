namespace Nemonuri;

public interface IReceiver
{
    void OnReceived(object? provider, object? received);
}

public interface IReceiver<T> : IReceiver
{
    void OnReceived(object? provider, T? received);
}