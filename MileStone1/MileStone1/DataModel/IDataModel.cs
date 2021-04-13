using System.ComponentModel;

namespace MileStone1 {
    interface IDataModel : INotifyPropertyChanged{
        //communication with the simulator
        void Connect(string ip, int port);
        void Disconnect();

        //flow
        void Start();

        void Stop();
        void Pause();
        void Resume();

        //timing
        double Time { get; set; }
        double Speed { get; set; }

        public delegate void UseAttributeUpdate(object sender, string propety, double newValue);
        public event UseAttributeUpdate UpdateAttribute;
    }
}