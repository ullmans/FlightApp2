using System.ComponentModel;

namespace MileStone1 {
    public interface IDataModel : INotifyPropertyChanged{
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
        bool pause { get; set; }
        int lines { get; set; }
        int position { get; set; }

        public delegate void UseAttributeUpdate(object sender, string property, double newValue);
        public event UseAttributeUpdate UpdateAttribute;
    }
}