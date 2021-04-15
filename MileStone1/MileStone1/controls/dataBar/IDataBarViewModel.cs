using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MileStone1
{
    public interface IDataBarViewModel: INotifyPropertyChanged
    {
        public double Altimeter{get; set; }
        public double AirSpeed{get; set; }
        public double Heading{get; set; }
        public double Pitch{get; set; }
        public double Roll{get; set; }
        public double Yaw{ get; set; }

    }
}
