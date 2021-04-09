
interface ITalnetClient
{
    void Connect(string ip, int port);
    void Write(string command);
    string Read(); // blocking call
    void Disconnect();
}
