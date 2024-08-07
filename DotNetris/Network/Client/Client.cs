namespace DotNetris.Network.Client;

public class Client
{
    private ClientConfig _conf;

    //private Thread? clientThread;
    
    public Client(ClientConfig config)
    {
        config.Validate();
        _conf = config;
    }
}