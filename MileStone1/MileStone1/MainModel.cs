using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using ICSharpCode.AvalonEdit.Utils;
using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;

namespace ex1
{
    class MainModel: IPlaneModel
    {
        bool stop;
        ITalnetClient talnetClient;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainModel(ITalnetClient tc)
        {
            this.talnetClient = tc;
            stop = false;
        }

        public void Connect(string ip, int port)
        {
            this.talnetClient.Connect(ip, port);
        }

        public void Disconnect()
        {
            stop = true;
            talnetClient.Disconnect();
        }

        public void Start(string path)
        {
            //TcpClient client = new TcpClient("localhost", 8081);
            //NetworkStream stream = client.GetStream();
            new Thread(delegate () 
            {
                using (TextReader connectionReader = new StreamReader(path))    //"./reg_flight.csv"
                {
                    string line;
                    while (!stop && ((line = connectionReader.ReadLine()) != null))
                    {
                        Console.WriteLine(line);
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(line);
                        stringBuilder.Append("\n");

                        //Byte[] msg = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                        //stream.Write(msg, 0, msg.Length);
                        this.talnetClient.Write(stringBuilder.ToString());
                        Thread.Sleep(100);
                    }
                }
            }).Start();
            /*using (TextReader connectionReader = new StreamReader("./reg_flight.csv"))
            {
                string line;
                while ((line = connectionReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(line);
                    stringBuilder.Append("\n");

                    //Byte[] msg = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                    //stream.Write(msg, 0, msg.Length);
                    
                    Thread.Sleep(100);
                }
            }
            stream.Close();
            client.Close();*/
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private double height;
        public double Height
        {
            get{ return height;}
            set
            {
                height = value;
                NotifyPropertyChanged("height");
            }
        }
        private double speed;
        public double Speed
        {
            get{ return speed; }
            set
            {
            speed = value;
            NotifyPropertyChanged("speed");
            }
        }
        private double pitch;
        public double Pitch
        {
            get{ return pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("pitch");
            }
        }
        private double roll;
        public double Roll
        {
            get{ return roll; }
            set
            {
                roll = value;
                NotifyPropertyChanged("roll");
                }
        }
        private double yaw;
        public double Yaw
        {
            get{ return yaw; }
            set
            {
                yaw = value;
                NotifyPropertyChanged("yaw");
            }
        }
        private double time;
        public double Time
        {
                get{ return time; }
            set
            {
                time = value;
                NotifyPropertyChanged("time");
                }
            }
        private double playSpeed;
        public double PlaySpeed
        {
            get { return playSpeed; }
            set
            {
                playSpeed = value;
                NotifyPropertyChanged("playSpeed");
            }
        }
    }
}
