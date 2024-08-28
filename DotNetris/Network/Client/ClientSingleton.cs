namespace DotNetris.Network.Client;

public static class ClientSingleton
{
    public static Client? client = null;

    public static bool IsConnecteed
    {
        get => client?.IsConnected ?? false;
    }

    public static bool IsLoggedIn {
        get => client?.LoggedIn ?? false;
    }
    
}