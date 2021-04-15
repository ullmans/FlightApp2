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
        private readonly string CSV_EXTENTION = ".csv";
        private readonly string XML_EXTENTION = ".xml";

        private readonly string STATE_LOADING = "Loading...";
        private readonly string STATE_READY = "Ready!";

        private IFileReadViewModel viewModel;

        private bool dataReadFinished;
        private bool definitionsReadFinished;

        public MainWindow() {
            InitializeComponent();
            viewModel = new FileReadViewModel(new FileReadModel());
            dataReadFinished = false;
            definitionsReadFinished = false;
            viewModel.FileReadFinished += useResults;
            /////////////////////////////////////////
            /*
            viewModel.DataFilePath = "C:\\Users\\BenZvi\\Downloads\\reg_flight (1).csv";
            viewModel.DefinitionsFilePath = "C:\\Users\\BenZvi\\Downloads\\playback_small.xml";
            viewModel.ReadFile(FileType.Data);
            viewModel.ReadFile(FileType.Definitions);
            */
            /////////////////////////////////////////
        }

        private void b_browseData_Click(Object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = CSV_EXTENTION;
            fileDialog.ShowDialog();
            t_dataFilePath.Text = fileDialog.FileName;
            t_dataLoadState.Text = STATE_LOADING;
            viewModel.DataFilePath = fileDialog.FileName;
            viewModel.ReadFile(FileType.Data);
        }
        private void b_browseDefinitions_Click(Object sender, RoutedEventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = XML_EXTENTION;
            fileDialog.ShowDialog();
            t_definitionsFilePath.Text = fileDialog.FileName;
            t_definitionsLoadState.Text = STATE_LOADING;
            viewModel.DefinitionsFilePath = fileDialog.FileName;
            viewModel.ReadFile(FileType.Definitions);
        }

        private void useResults(Object sender, FileType fileType) {
            if (sender as IFileReadViewModel == viewModel) {
                if (fileType == FileType.Data) {
                    t_dataLoadState.Text = STATE_READY;
                    dataReadFinished = true;
                }
                if (fileType == FileType.Definitions) {
                    t_definitionsLoadState.Text = STATE_READY;
                    definitionsReadFinished = true;
                }
                if (dataReadFinished && definitionsReadFinished) {
                    b_start.IsEnabled = true;
                }
            }
        }

        private void b_start_Click(Object sender, RoutedEventArgs e) {
            DataView dataView = new DataView(viewModel.GetDataLog(), viewModel.GetDefinitions(), viewModel.GetSampleRate());
            dataView.Show();
            this.Close();
        }
    }
}