using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;
//using ICSharpCode.AvalonEdit.Utils;
using System.ComponentModel;

namespace MileStone1 
{
    class FileReadModel: IFileReadModel
    {
        bool stop;
        ITelnetClient telnetClient;
        List<double[]> dataLogCSV;
        List<string> props; //properties
        public event PropertyChangedEventHandler PropertyChanged;

        public FileReadModel(ITelnetClient tc)
        {
            this.telnetClient = tc;
            stop = false;
            dataLogCSV = new List<double[]>();
            props = new List<string>();
        }
        public void ReadDataFile(string filePath)
        {
            using (TextReader connectionReader = new StreamReader(filePath))    //"./reg_flight.csv"
            {
                string line;
                while ((line = connectionReader.ReadLine()) != null)
                {
                    string[] splittedLine = line.Split(',');
                    double[] lineInNumbers = new double[splittedLine.Length];
                    for (int i = 0; i < splittedLine.Length; ++i)
                    {
                        lineInNumbers[i] = double.Parse(splittedLine[i]);
                    }
                }
            }
        }

        public List<double[]> GetDataLog()
        {
            return dataLogCSV;
        }

        public void ReadDefinitionFile(string filePath)
        {
            using (TextReader connectionReader = new StreamReader(filePath))    //"./reg_flight.csv"
            {
                string line;
                while ((line = connectionReader.ReadLine()) != null)
                {
                    string[] splittedLine = line.Split('>');
                    if (splittedLine[0].Equals("<name"))
                    {
                        props.Add((splittedLine[1].Split('<'))[0]);
                    }
                }
            }
        }
        public List<string> GetDefinitions()
        {
            return this.props;
        }


        public void Connect(string ip, int port)
        {
            this.telnetClient.Connect(ip, port);
        }

        public void Disconnect()
        {
            stop = true;
            telnetClient.Disconnect();
        }

        public void Start(string path)
        {
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
                        this.telnetClient.Write(stringBuilder.ToString());
                        Thread.Sleep(100);
                    }
                }
            }).Start();
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        //the properties of the plane
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
