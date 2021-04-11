using System;
using System.ComponentModel;

interface IControlBarModel : INotifyPropertyChanged
{
    bool running { get; set; }
    int steps { get; set; }
    int position { get; set; }
    int playSpeed { get; set; }

    void move();
}
