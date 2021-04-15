using System;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;

namespace MileStone1.controls {
    /// <summary>
    /// Interaction logic for joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl {
        private readonly int JOYSTICK_SIZE = 250;
        private readonly int PROPERTY_MIN = -1;
        private readonly int PROPERTY_MAX = 1;

        private IJoystickViewModel viewModel;

        public Joystick() {
            InitializeComponent();
        }

        public void SetVM(IJoystickViewModel newViewModel) {
            if (viewModel == null) {
                viewModel = newViewModel;
                viewModel.PropertyChanged +=
                    delegate (Object sender, PropertyChangedEventArgs e) {
                        if (viewModel.VM_throttle == 0.2) {
                            //throw new Exception("here");
                        }
                        // set joystick position by property
                        string property = e.PropertyName;
                        if (property.Equals("VM_aileron")) {
                            this.Dispatcher.Invoke(() =>
                            {
                                var margin = Knob.Margin;
                                margin.Left = PropertToJoystickPosition(viewModel.VM_aileron);
                                Knob.Margin = margin;
                            });
                        } else if (property.Equals("VM_elevator")) {
                            this.Dispatcher.Invoke(() =>
                            {
                                var margin = Knob.Margin;
                                margin.Top = JOYSTICK_SIZE - PropertToJoystickPosition(viewModel.VM_elevator);
                                Knob.Margin = margin;
                            });
                        }
                    };
            }
            DataContext = viewModel;
        }

        // linear transformation from range [PROPERTY_MIN,PROPERTY_MAX] to [0,JOYSTICK_SIZE]
        private int PropertToJoystickPosition(double value) {
            return (int)((value - PROPERTY_MIN) * JOYSTICK_SIZE / (PROPERTY_MAX - PROPERTY_MIN));
        }
    }
}
