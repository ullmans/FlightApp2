using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using MileStone1;

namespace MileStone1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private const string CSV_EXTENTION = ".csv";
        private const string STATE_GENERATING_SIMULATION = "Generating simulation...";
        private const string STATE_DONE = "Done!";

        private IPlaneViewModel viewModel;

        public MainWindow() {
            InitializeComponent();
            viewModel = new MainPlaneViewModel(new MainModel(new TelentClient()));
            DataContext = viewModel;
        }

        private void b_browse_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".csv";
            fileDialog.ShowDialog();
            t_filePath.Text = fileDialog.FileName;
            viewModel.VM_FilePath = fileDialog.FileName;
            b_start.IsEnabled = true;
        }

        private void b_start_Click(object sender, RoutedEventArgs e) {
            viewModel.StartSimulation();
        }
    }
}