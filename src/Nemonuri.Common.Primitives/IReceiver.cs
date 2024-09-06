namespace Nemonuri;

public interface IReceiver<T>
{
    void OnReceived(object? provider, T received);
}