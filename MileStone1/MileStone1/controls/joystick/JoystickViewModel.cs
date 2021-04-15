using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace MileStone1 {
    class JoystickViewModel : IJoystickViewModel {
        // joystick properties
        private readonly string AILERON = "aileron";
        private readonly string ELEVATOR = "elevator";
        private readonly string THROTTLE = "throttle";
        private readonly string RUDDER = "rudder";

        private IDataModel model;
        // matches property name to its value
        private Dictionary<string, double> properties;

        public double VM_aileron {
            get {
                return properties[AILERON];
            }
        }
        public double VM_elevator {
            get {
                return properties[ELEVATOR];
            }
        }
        public double VM_throttle {
            get {
                return properties[THROTTLE];
            }
        }
        public double VM_rudder {
            get {
                return properties[RUDDER];
            }
        }


        public JoystickViewModel(IDataModel model) {
            this.model = model;
            this.model.UpdateAttribute += UseAttributeUpdate;
            properties = new Dictionary<string, double>();
            properties.Add(AILERON, 0);
            properties.Add(ELEVATOR, 0);
            properties.Add(THROTTLE, 0);
            properties.Add(RUDDER, 0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void UseAttributeUpdate(Object sender, string property, double newValue) {
            if (properties.ContainsKey(property)) {
                properties[property] = newValue;
                NotifyPropertyChanged("VM_" + property);
            }
        }
    }
}
