using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1
{
    public interface IDataBarViewModel
    {
        public double Altimeter{get; set; }
        public double Airspeed{get; set; }
        public double Heading{get; set; }
        public double Pitch{get; set; }
        public double Roll{get; set; }
        public double Yaw{ get; set; }

    }
}
