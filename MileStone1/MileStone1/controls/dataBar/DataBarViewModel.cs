using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MileStone1.controls.dataBar
{
    class DataBarViewModel //:  INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
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
        /*public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }*/

        private void UseAttributeUpdate(object sender, string property, double newValue)
        {
            if (sender as IDataModel == model)
            {
                if (property.Equals("altimeter"))
                {
                    altimeter = newValue;
                }
                else if (property.Equals("airSpeed"))
                {
                    airSpeed = newValue;
                }
                else if (property.Equals("rudder")) //כיוון
                {
                    rudder = newValue;
                }
                else if (property.Equals("Pitch"))
                {
                    pitch = newValue;
                }
                else if (property.Equals("Roll"))
                {
                    roll = newValue;
                }
                else if (property.Equals("Yaw"))
                {
                    yaw = newValue;
                }
            }
        }

        private double altimeter;
        public double Altimeter
        {
            get { return altimeter; }
            set { altimeter = value; }
        }

        private double airSpeed;
        public double Airspeed
        {
            get { return airSpeed; }
            set { airSpeed = value; }
        }

        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set { rudder = value; }
        }

        private double pitch;
        public double Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        private double roll;
        public double Roll
        {
            get { return roll; }
            set { roll = value; }
        }

        private double yaw;
        public double Yaw
        {
            get { return yaw; }
            set { yaw = value; }
        }
    }
}
