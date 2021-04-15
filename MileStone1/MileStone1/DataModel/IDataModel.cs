using System.ComponentModel;
using System;

namespace MileStone1 {
    public interface IDataModel : INotifyPropertyChanged{
        //communication with the simulator
        void Connect(string ip, int port);
        void Disconnect();

        //flow
        void Start();
        void Stop();
        void Pause();

        //timing
        double Time { get; set; }
        double Speed { get; set; }
        bool Paused { get; set; }
        double GetSimulationTime();

        // update when a new value for a plane attribute is scanned
        public delegate void UseAttributeUpdate(Object sender, string property, double newValue);
        public event UseAttributeUpdate UpdateAttribute;

        // update when data scan is finished
        public delegate void EndRun(Object sender);
        public event EndRun ScanFinished;
    }
}