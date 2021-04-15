using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace MileStone1 {
    public class DataModel : IDataModel {
        private readonly string LOCALHOST = "localhost";
        private readonly int FLIGHTGEAR_PORT = 8081;

        private readonly double MIN_SPEED = 0.1;
        private readonly double MAX_SPEED = 2;
        private readonly double EPSILON = 0.0001;

        private readonly int MILLISECONDS_IN_A_SECOND = 1000;
        // data lines per second (constant default value)
        private double sampleRate;
        // milliseconds per data line (affected by simulation speed)
        private int lineDelayInMillis;

        private ITelnetClient telnetClient;
        private List<double[]> data;
        private List<string> definitions;

        private bool paused, stop;

        public DataModel(ITelnetClient telnetClient, List<double[]> data, List<string> definitions, double sampleRate) {
            this.telnetClient = telnetClient;
            telnetClient.Connect(LOCALHOST, FLIGHTGEAR_PORT);
            this.data = data;
            this.definitions = definitions;
            this.sampleRate = 100;
            //this.sampleRate = sampleRate;
            lineDelayInMillis = (int)(MILLISECONDS_IN_A_SECOND / sampleRate);
            Time = 0;
            Speed = 1;
            stop = false;
            paused = false;
        }

        public bool Paused
        {
            get { return paused; }
            set
            {
                if (paused != value)
                {
                    paused = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event IDataModel.UseAttributeUpdate UpdateAttribute;
        public event IDataModel.EndRun ScanFinished;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private int rowIndex;

        private double time;
        public double Time {
            get {
                return time;
            }
            set {
                time = value;
                rowIndex = (int)(value * sampleRate);
            }
        }

        private double speed;
        public double Speed {
            get {
                return speed;
            }
            set {
                if (MIN_SPEED - EPSILON  <= value && value <= MAX_SPEED + EPSILON) {
                    speed = value;
                }
                lineDelayInMillis = (int)(MILLISECONDS_IN_A_SECOND / sampleRate / speed);
                NotifyPropertyChanged("Speed");
            }
        }

        

        public void Connect(string ip, int port) {
            telnetClient.Connect(ip, port);
        }

        public void Disconnect() {
            telnetClient.Disconnect();
        }

        public void Start() {
            paused = false;
            new Thread(delegate () {
                int numberOfSamples = data.Count;
                int numberOfAttributes = data[0].Length;
                while (!stop && !paused && rowIndex < numberOfSamples) {
                    // send updates about line value one by one
                    StringBuilder sb = new StringBuilder();
                    for (int colIndex = 0; colIndex < numberOfAttributes; ++colIndex) {
                        if (UpdateAttribute != null) {
                            UpdateAttribute(this, definitions[colIndex], data[rowIndex][colIndex]);
                        }
                        sb.Append(data[rowIndex][colIndex]);
                        sb.Append(',');
                    }
                    ++rowIndex;
                    //sb.Append("\n");
                    telnetClient.Write(sb.ToString().Substring(0, sb.ToString().Length - 1) + "\n");
                    Thread.Sleep(lineDelayInMillis);
                    time += 1 / sampleRate;
                    NotifyPropertyChanged("Time");
                }
                if (ScanFinished != null) {
                    ScanFinished(this);
                }
            }).Start();
        }


        public void Stop()
        {
            stop = true;
        }

        public void Pause()
        {
            paused = true;
        }

        public double GetSimulationTime() {
            return (data.Count / sampleRate);
        }

    }
}
