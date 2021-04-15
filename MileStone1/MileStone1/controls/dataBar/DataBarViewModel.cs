using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MileStone1
{
    class DataBarViewModel : IDataBarViewModel//:  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IDataModel model;

        public DataBarViewModel(IDataModel model)
        {
            this.model = model;
            /*this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };*/
            this.model.UpdateAttribute += UseAttributeUpdate;
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void UseAttributeUpdate(Object sender, string property, double newValue)
        {
            if (sender as IDataModel == model)
            {
                if (property.Equals("altimeter_indicated-altitude-ft"))
                {
                    altimeter = newValue;
                }
                else if (property.Equals("airspeed-kt"))
                {
                    airSpeed = newValue;
                }
                else if (property.Equals("heading-deg"))
                {
                    heading = newValue;
                }
                else if (property.Equals("pitch-deg"))
                {
                    pitch = newValue;
                }
                else if (property.Equals("roll-deg"))
                {
                    roll = newValue;
                }
                else if (property.Equals("side-slip-deg"))
                {
                    yaw = newValue;
                }
            }
        }

        private double altimeter;
        public double Altimeter
        {
            get { return altimeter; }
            set 
            { 
                altimeter = value;
                NotifyPropertyChanged("Altimeter");
            }
        }

        private double airSpeed;
        public double AirSpeed
        {
            get { return airSpeed; }
            set 
            { 
                airSpeed = value;
                NotifyPropertyChanged("AirSpeed");
            }
        }

        private double heading;
        public double Heading
        {
            get { return heading; }
            set 
            { 
                heading = value;
                NotifyPropertyChanged("Heading");
            }
        }

        private double pitch;
        public double Pitch
        {
            get { return pitch; }
            set 
            { 
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }

        private double roll;
        public double Roll
        {
            get { return roll; }
            set 
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }

        private double yaw;
        public double Yaw
        {
            get { return yaw; }
            set 
            {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }
    }
}
