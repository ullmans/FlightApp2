
interface ITelnetClient
{
void connect(string ip, int port);
void write(string command);
string read(); // blocking call
void disconnect();
}