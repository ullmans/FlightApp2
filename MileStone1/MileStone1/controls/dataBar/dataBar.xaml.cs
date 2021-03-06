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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MileStone1.controls {
    /// <summary>
    /// Interaction logic for dataBar.xaml
    /// </summary>
    public partial class DataBar : UserControl {
        private IDataBarViewModel dbvm;
        public DataBar() {
            InitializeComponent();
        }

        public void SetVM(IDataBarViewModel vm)
        {
            dbvm = vm;    //IDataBarViewModel
            DataContext = dbvm;
        }
    }
}
