using System;
using System.ComponentModel;

interface IControlBarModel : INotifyPropertyChanged
{
    bool running { get; set; }
    int lines { get; set; }
    int position { get; set; }
    int playSpeed { get; set; }

    void move();
}
