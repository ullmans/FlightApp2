using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MileStone1.dataModel {
    class DataModel : IDataModel {
        private const int MILLISECONDS_PER_DATA_LINE = 100;
        private const double MILLISECONDS_IN_A_SECOND = 1000;
        private const double DATA_LINES_PER_SECOND = MILLISECONDS_IN_A_SECOND / MILLISECONDS_PER_DATA_LINE;

        private ITelnetClient telnetClient;
        private double[][] data;

        private bool pause, stop;

        public delegate void UsePropertyUpdate(string propety, double newValue);
        public event UsePropertyUpdate PropertyUpdated;

        private int rowIndex;
        public double Time {
            get {
                return rowIndex / DATA_LINES_PER_SECOND;
            }
            set {
                rowIndex = (int)(value * DATA_LINES_PER_SECOND);
            }
        }

        private double speed;
        public double Speed {
            get {
                return speed;
            }
            set {
                speed = value;
            }
        }

        public DataModel(ITelnetClient telnetClient, double[][] data) {
            this.telnetClient = telnetClient;
            this.data = data;
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
                while (!stop && !pause && rowIndex < data.Length) {

                }
            }).Start();
        }
    }
}
