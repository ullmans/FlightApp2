using System;
using System.ComponentModel;

namespace MileStone1
{
    public interface IgraphViewModel : INotifyPropertyChanged
    {
        public void updateDots(int chosen);
    }
}
