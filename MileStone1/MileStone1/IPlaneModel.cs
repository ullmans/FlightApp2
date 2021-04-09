﻿using System.ComponentModel;
interface IPlaneModel : INotifyPropertyChanged
{
    //communication with the simulator
    void Connect(string ip, int port);
    void Disconnect();

    void Start(string path);
    //void Stop();

    //properties
    double Height { set; get; }
    double Speed { set; get; }
    double Pitch { set; get; }
    double Roll { set; get; }
    double Yaw { set; get; }
    double Time { get; set; }
    double PlaySpeed { get; set; }



}