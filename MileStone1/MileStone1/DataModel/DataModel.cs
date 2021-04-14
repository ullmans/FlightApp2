using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace MileStone1.dataModel {
    public class DataModel : IDataModel {
        private const int MILLISECONDS_IN_A_SECOND = 1000;
        // data lines per second (constant default value)
        private int sampleRate;
        // milliseconds per data line (affected by simulation speed)
        private int lineDelayInMillis;

        private ITelnetClient telnetClient;
        private List<double[]> data;
        private List<string> definitions;

        private bool paused, stop;

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
        public int Position
        {
            get { return rowIndex; }
            set
            {
                if (rowIndex != value)
                {
                    rowIndex = value;
                    NotifyPropertyChanged("Position");
                }
            }
        }

        private double time;
        public double Time {
            get {
                return time;
            }
            set {
                time = value;
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

        public DataModel(ITelnetClient telnetClient, List<double[]> data, List<string> definitions, int sampleRate) {
            this.telnetClient = telnetClient;
            this.data = data;
            this.definitions = definitions;
            this.sampleRate = sampleRate;
            lineDelayInMillis = MILLISECONDS_IN_A_SECOND / sampleRate;
            Time = 0;
            Speed = 1;
            stop = false;
            paused = false;
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
                int numberOfAttributes = lines = data[0].Length;
                while (!stop && !paused && rowIndex < numberOfSamples) {
                    for (int colIndex = 0; colIndex < numberOfAttributes; ++colIndex)
                    {
                        UpdateAttribute(this, definitions[colIndex], data[rowIndex][colIndex]);
                        // send data to FlightGear
                    }
                    ++rowIndex;
                    Thread.Sleep(lineDelayInMillis);
                    Time += (double)lineDelayInMillis / MILLISECONDS_IN_A_SECOND;
                }
            }).Start();
        }

        private int lines;
        public int Lines
        {
            get { return lines; }
            set
            {
                if (lines != value)
                {
                    lines = value;
                    NotifyPropertyChanged("lines");
                }
            }
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
    }
}
