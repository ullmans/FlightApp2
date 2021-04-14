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

        private bool _pause, stop;

        public bool pause
        {
            get { return _pause; }
            set
            {
                if (_pause != value)
                {
                    _pause = value;
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
        public int position
        {
            get { return position; }
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
            pause = false;
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
                int numberOfAttributes = _lines = data[0].Length;
                while (!stop && !pause && rowIndex < numberOfSamples) {
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

        private int _lines;
        public int lines
        {
            get { return _lines; }
            set
            {
                if (_lines != value)
                {
                    _lines = value;
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
            pause = true;
        }

        public void Resume()
        {
            pause = false;
            Start();
        }
    }
}
