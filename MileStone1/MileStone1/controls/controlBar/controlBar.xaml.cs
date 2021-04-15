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
using System.ComponentModel;

// code behind for control bar user control
namespace MileStone1.controls
{
    public partial class ControlBar : UserControl
    {
        private readonly int MAX_PERCENT = 100;
        private readonly string PERCENT_SIGN = "%";

        // the control bar's view model
        private IControlBarViewModel vm;

        // constructor
        public ControlBar() {
            InitializeComponent();
            b_pause.IsEnabled = false;
        }

        // sets the control bar's view model
        public void SetVM(IControlBarViewModel newVM) {
            vm = newVM;            
            DataContext = vm;
            vm.SimulationFinished += delegate (Object sender) {
                this.Dispatcher.Invoke(() => {
                    b_play.IsEnabled = true;
                    b_pause.IsEnabled = false;
                });
            };
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName.Equals("VM_Position")) {
                    this.Dispatcher.Invoke(() => {
                        int percentComplete = (int)(vm.VM_Position / progressBar.Maximum * MAX_PERCENT);
                        if (percentComplete > MAX_PERCENT) {
                            percentComplete = MAX_PERCENT;
                        }
                        t_progress.Text = percentComplete.ToString() + PERCENT_SIGN;
                    });
                } else if (e.PropertyName.Equals("VM_PlaySpeed")) {
                    this.Dispatcher.Invoke(() => {
                        t_playSpeed.Text = vm.VM_PlaySpeed.ToString();
                    });
                }
            };
        }

        // returns to start of flight
        private void B_start_Click(Object sender, RoutedEventArgs e) {
            //t_progress.Text = "0%";
            progressBar.Value = 0;
        }

        // decreases the play speed
        private void B_slowDown_Click(Object sender, RoutedEventArgs e) {
            vm.DecreaseSpeed();
        }

        // pauses the flight display
        private void B_pause_Click(Object sender, RoutedEventArgs e) {
            vm.Pause();
            b_pause.IsEnabled = false;
            b_play.IsEnabled = true;
        }

        // unpauses the flight display
        private void B_play_Click(Object sender, RoutedEventArgs e) {
            vm.Play();
            b_play.IsEnabled = false;
            b_pause.IsEnabled = true;
        }

        // increases the flight display's speed
        private void B_speedUp_Click(Object sender, RoutedEventArgs e) {
            vm.IncreaseSpeed();
        }

        // jumps to end of flight
        private void B_end_Click(Object sender, RoutedEventArgs e) {
            //t_progress.Text = "100%";
            progressBar.Value = vm.VM_Lines;
        }
    }
}
