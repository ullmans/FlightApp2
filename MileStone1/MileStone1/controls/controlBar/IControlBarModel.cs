using System;
using System.ComponentModel;

// interface for control bar models

namespace MileStone1 {
    public interface IControlBarModel : INotifyPropertyChanged {
        // number of lines in a flight file
        int Lines { get; }
        // line in flight file the flight display is showing
        double Position { get; set; }
        // the speed at which the flight display is running
        double PlaySpeed { get; set; }

        void Play();
        void Pause();

        // event for when the simulation finished
        public delegate void EndRun(Object sender);
        public event EndRun SimulationFinished;
    }
}

