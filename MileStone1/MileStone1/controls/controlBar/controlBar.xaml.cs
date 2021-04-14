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
        // the control bar's view model
        private ControlBarViewModel vm;

        // constructor
        public ControlBar()
        {
            InitializeComponent();
        }

        // sets the control bar's view model
        public void SetVM(ControlBarViewModel newVM)
        {
            vm = newVM;
            // adds delegate function to view model that updates the slider's value
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_position")
                {
                    progressBar.Value = vm.VM_position;
                }
            };
        }

        // returns to start of flight
        private void B_start_Click(object sender, RoutedEventArgs e)
        {
            vm.GoToStart();
            t_progress.Text = "0%";
            progressBar.Value = 0;
        }
        // decreases the play speed
        private void B_slowDown_Click(object sender, RoutedEventArgs e)
        {
            vm.DecreaseSpeed();
            if (vm.VM_playSpeed < 0.1)
            {
                t_playSpeed.Text = "0";
            }
        }
        // pauses the flight display
        private void B_pause_Click(object sender, RoutedEventArgs e)
        {
            vm.Pause();
        }
        // unpauses the flight display
        private void B_play_Click(object sender, RoutedEventArgs e)
        {
            vm.Play();
        }
        // increases the flight display's speed
        private void B_speedUp_Click(object sender, RoutedEventArgs e)
        {
            vm.IncreaseSpeed();
        }
        // jumps to end of flight
        private void B_end_Click(object sender, RoutedEventArgs e)
        {
            vm.GoToEnd();
            t_progress.Text = "100%";
            progressBar.Value = vm.VM_lines;
        }
        // updates the progress label's content and position property when
        // slider is moved by user
        private void SliderValueChanged(object sender, RoutedEventArgs e)
        {
            vm.SkipTo(Convert.ToInt32(progressBar.Value));
            t_progress.Text = (Convert.ToInt32(vm.VM_position * 100 / vm.VM_lines)).ToString() + "%";
        }
    }
}
