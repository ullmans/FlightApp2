using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace MileStone1 {
    public class DataModel : IDataModel {
        private const int MILLISECONDS_IN_A_SECOND = 1000;
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
            this.data = data;
            this.definitions = definitions;
            this.sampleRate = 100;
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

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event IDataModel.UseAttributeUpdate UpdateAttribute;

        private int rowIndex;

        private double time;
        public double Time {
            get {
                return time;
            }
            set {
                time = value;
                rowIndex = (int)(value * sampleRate);
                NotifyPropertyChanged("Time");
            }
        }

        private double speed;
        public double Speed {
            get {
                return speed;
            }
            set {
                speed = value;
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
            new Thread(delegate () {
                int numberOfSamples = data.Count;
                int numberOfAttributes = data[0].Length;
                while (!stop && !paused && rowIndex < numberOfSamples) {
                    // send updates about line value one by one
                    for (int colIndex = 0; colIndex < numberOfAttributes; ++colIndex) {
                        if (UpdateAttribute != null) {
                            UpdateAttribute(this, definitions[colIndex], data[rowIndex][colIndex]);
                        }
                        // send data to FlightGear
                    }
                    ++rowIndex;
                    Thread.Sleep(lineDelayInMillis);
                    Time += (double)lineDelayInMillis / MILLISECONDS_IN_A_SECOND;
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

        public void Resume()
        {
            paused = false;
            Start();
        }

        public double GetSimulationTime() {
            return (data.Count * sampleRate);
        }

    }
}
