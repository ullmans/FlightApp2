using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1.dataModel {
    class DataModel : IDataModel {
        private const int DEFAULT_INTERVAL_IN_MILLIS = 100;

        private ITelnetClient telnetClient;
        private double[][] data;
        public delegate void UsePropertyUpdate(string propety, double newValue);
        public event UsePropertyUpdate PropertyUpdated;

        private double time;
        public double Time {
            get {
                return time;
            }
            set {
                time = value;
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
        }

        public void Connect(string ip, int port) {
            telnetClient.Connect(ip, port);
        }

        public void Disconnect() {
            telnetClient.Disconnect();
        }

        public void Start() {

        }
    }
}
