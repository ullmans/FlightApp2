using System;
using System.Windows.Controls;
using System.ComponentModel;


namespace MileStone1 {
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

        public void SetViewModel(IJoystickViewModel newViewModel) {
            if (viewModel == null) {
                viewModel = newViewModel;
                viewModel.PropertyChanged +=
                    delegate (Object sender, PropertyChangedEventArgs e) {
                        // set joystick position by property
                        string property = e.PropertyName;
                        if (e.Equals("VM_aileron")) {
                            Canvas.SetLeft(Knob, PropertToJoystickPosition(viewModel.VM_aileron));
                        } else if (e.Equals("VM_elevator")) {
                            Canvas.SetBottom(Knob, PropertToJoystickPosition(viewModel.VM_elevator));
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
