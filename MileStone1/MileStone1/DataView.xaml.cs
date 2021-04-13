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
        public DataView() {
            InitializeComponent();
            control_bar.setVM(new ControlBarViewModel(new ControlBarModel(1000))); // replace 1000 with lines
        }

        private void control_bar_Loaded(object sender, RoutedEventArgs e) {

        }

        private void button_Click(object sender, RoutedEventArgs e) {

        }
    }
}
