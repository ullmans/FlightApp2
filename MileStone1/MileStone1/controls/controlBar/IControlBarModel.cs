using System;
using System.ComponentModel;

public interface IControlBarModel : INotifyPropertyChanged
{
    bool running { get; set; }
    int lines { get; set; }
    int position { get; set; }
    double playSpeed { get; set; }

    void move();
}
