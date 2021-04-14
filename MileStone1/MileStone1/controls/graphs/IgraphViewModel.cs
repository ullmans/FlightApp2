using System;
using System.ComponentModel;


public interface IgraphViewModel : INotifyPropertyChanged
{
    public void updateDots(int chosen);
}
