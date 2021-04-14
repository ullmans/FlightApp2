using System;
using System.ComponentModel;

// interface for control bar models
public interface IControlBarModel : INotifyPropertyChanged
{
    // says whether or not the plane display should be running
    bool running { get; set; }
    // number of lines in a flight file
    int lines { get; set; }
    // line in flight file the flight display is showing
    int position { get; set; }
    // the speed at which the flight display is running
    double playSpeed { get; set; }

    // updates control bar after moving to next line in flight file
    void Move();
}
