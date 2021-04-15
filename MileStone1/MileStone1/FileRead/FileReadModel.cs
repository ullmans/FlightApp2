using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;
//using ICSharpCode.AvalonEdit.Utils;
using System.ComponentModel;

namespace MileStone1 
{
    class FileReadModel : IFileReadModel
    {
        //bool stop;
        //ITelnetClient telnetClient;
        List<double[]> dataLogCSV;
        List<string> props; //properties
        double sampleRate;  //number of kines in one second
        //public event PropertyChangedEventHandler PropertyChanged;     ????
        public event IFileReadModel.UseResult FileReadFinished;


        public FileReadModel()
        {
            //this.telnetClient = tc;
            //stop = false;
            dataLogCSV = new List<double[]>();  //save the lines of the csv file
            props = new List<string>(); 
        }
        public void ReadFile(string filePath, FileType fileType)
        {
            if (fileType == FileType.Data)  //CSV file
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
                        dataLogCSV.Add(lineInNumbers);
                    }
                }
                
                this.ReadyToUseResult(fileType);
            } 
            else if (fileType == FileType.Definitions)  //xaml file
            {
                using (TextReader connectionReader = new StreamReader(filePath))    //"./reg_flight.csv"
                {
                    string line;
                    bool isSampleRateFound = false;
                    while ((line = connectionReader.ReadLine()) != null)
                    {
                        string[] splittedLine = line.Split('>');

                        if (splittedLine[0].Replace(" ", String.Empty).Equals("<name"))
                        {
                            StringBuilder propertyBuilder = new StringBuilder((splittedLine[1].Split('<'))[0]);
                            if (props.Contains(propertyBuilder.ToString())) {
                                propertyBuilder.Append("2");
                            }
                            props.Add(propertyBuilder.ToString());
                        }
                        if (!isSampleRateFound)
                        {
                            string[] findSampleRate = line.Split(':');
                            if (findSampleRate[0].Equals("Recording"))
                            {
                                this.sampleRate = double.Parse(((findSampleRate[1]).Split(','))[2]);
                                isSampleRateFound = true;
                            }
                        }
                    }
                }
                this.ReadyToUseResult(fileType);
            }
        }

        //a func like NotifyPropertyChanged for the UseRedultEvent....
        public void ReadyToUseResult(FileType fileType)
        {
            if(this.FileReadFinished != null)
            {
                this.FileReadFinished(this, fileType);
            }
        }

        public List<double[]> GetDataLog()
        {
            return dataLogCSV;
        }
        public double GetSampleRate()   //what that func do?
        {
            return 2.0; 
        }


        /*public void ReadDefinitionFile(string filePath, FileType fileType)
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
            this.ReadyToUseResult(fileType);
        }*/
        public List<string> GetDefinitions()
        {
            return this.props;
        }


        /*public void Connect(string ip, int port)
        {
            this.telnetClient.Connect(ip, port);
        }

        public void Disconnect()
        {
            stop = true;
            telnetClient.Disconnect();
        }*/

        /*public void Start(string path)
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
        }*/

        /*
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }*/

        /*
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
        }*/
    }
}
