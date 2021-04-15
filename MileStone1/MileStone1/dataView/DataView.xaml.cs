using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MileStone1 {
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataView : Window {
        public DataView(List<double[]> dataLog, List<string> definitions, double sampleRate) {
            InitializeComponent();
            IDataModel model = new DataModel(new TelnetClient(), dataLog, definitions, sampleRate);
            control_bar.SetVM(new ControlBarViewModel(new ControlBarModel(model)));
            data_bar.SetVM(new DataBarViewModel(model));
            joystick.SetVM(new JoystickViewModel(model));
            graph_bar.SetVM(dataLog);
        }
    }
}
