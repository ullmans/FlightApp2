using System.ComponentModel;
interface IPlaneModel : INotifyPropertyChanged
{
    //communication with the simulator
    void connect(string ip, int port);
    void disconnect();

    void start(string path);
    void Stop();

    //properties
    double Height { set; get; }
    double Speed { set; get; }
    double Pitch { set; get; }
    double Roll { set; get; }
    double Yaw { set; get; 
    double Time { get; set; }
    double PlaySpeed { get; set; }



}