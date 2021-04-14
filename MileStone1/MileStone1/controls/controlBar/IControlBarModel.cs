using System;
using System.ComponentModel;

// interface for control bar models

namespace MileStone1 {
    public interface IControlBarModel : INotifyPropertyChanged {
        // says whether or not the plane display should be running
        bool Running { get; set; }
        // number of lines in a flight file
        int Lines { get; }
        // line in flight file the flight display is showing
        int Position { get; set; }
        // the speed at which the flight display is running
        double PlaySpeed { get; set; }

        // updates control bar after moving to next line in flight file
        void Move();

        void Play();
        void Pause();
    }
}

