using System;
using System.ComponentModel;

public interface IControlBarViewModel : INotifyPropertyChanged
{
    int VM_Lines { get; }
    double VM_Position { get; }
    double VM_PlaySpeed { get; }

    void IncreaseSpeed();
    void DecreaseSpeed();
    void Pause();
    void Play();

    // event for when the simulation finished
    public delegate void EndRun(Object sender);
    public event EndRun SimulationFinished;
}