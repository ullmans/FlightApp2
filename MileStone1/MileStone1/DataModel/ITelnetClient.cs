
public interface ITelnetClient
{
    void Connect(string ip, int port);
    void Write(string command);
    void Disconnect();
}
