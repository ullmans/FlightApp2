using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1.controls.joystick {
    class ViewModel {
        private IDataModel model; 

        private double my_property;
        public double My_property {
            get {
                return my_property;
            }
            set {
                my_property = value;
            }
        }

        public ViewModel(IDataModel model) {
            this.model = model;
            model.UpdateAttribute += UseAttributeUpdate;
        }

        private void UseAttributeUpdate(object sender, string property, double newValue) {
            if (sender as IDataModel == model) {
                if (property.Equals("my_property")) {
                    My_property = newValue;
                }
            }
        }
    }
}
