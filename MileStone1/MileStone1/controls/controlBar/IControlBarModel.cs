using System;
using System.ComponentModel;

interface IControlBarModel : INotifyPropertyChanged
{
    bool running { get; set; }
    int lines { get; set; }
    int position { get; set; }
    double playSpeed { get; set; }

    void move();
}
