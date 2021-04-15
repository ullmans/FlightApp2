using System;
using System.Net.Sockets;
using System.Text;

namespace MileStone1 {
    class TelnetClient : ITelnetClient {
        private TcpClient client;

        public TelnetClient() {}

        public void Connect(string ip, int port) {
            client = new TcpClient(ip, port);
        }

        public void Write(string data) {
            NetworkStream stream = client.GetStream();
            Byte[] msg = Encoding.ASCII.GetBytes(data);
            stream.Write(msg, 0, msg.Length);
        }

        public void Disconnect() {
            client.Close();
        }
    }
}

