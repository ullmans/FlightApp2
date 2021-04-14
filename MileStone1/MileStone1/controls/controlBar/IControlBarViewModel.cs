using System;
using System.ComponentModel;

public interface IControlBarViewModel : INotifyPropertyChanged
{
    bool VM_running { get; }
    int VM_lines { get; }
    int VM_position { get; }
    double VM_playSpeed { get; }

    void GoToStart();
    void GoToEnd();
    void IncreaseSpeed();
    void DecreaseSpeed();
    void Pause();
    void Play();
    void SkipTo(int newPosition);
}