using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ICSharpCode.AvalonEdit.Utils;
using Microsoft.VisualBasic.FileIO;

namespace ex1
{
    class MainModel:
    {
        static void Main()
        {
            TcpClient client = new TcpClient("localhost", 8081);
            NetworkStream stream = client.GetStream();
            using (TextReader connectionReader = new StreamReader("./reg_flight.csv"))
            {
                string line;
                while ((line = connectionReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(line);
                    stringBuilder.Append("\n");

                    Byte[] msg = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                    stream.Write(msg, 0, msg.Length);
                    Thread.Sleep(100);
                }
            }
            stream.Close();
            client.Close();
        }
    }
}
