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

namespace MileStone1.controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
        private ControlBarViewModel vm;
        public ControlBar()
        {
            InitializeComponent();
            vm = new ControlBarViewModel(new ControlBarModel(200));
            DataContext = vm;
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_position")
                {
                    progressBar.Value = vm.VM_position;
                }
            };
        }

        private void b_start_Click(object sender, RoutedEventArgs e)
        {
            vm.goToStart();
            t_progress.Text = "0%";
            progressBar.Value = 0;
        }
        private void b_slowDown_Click(object sender, RoutedEventArgs e)
        {
            vm.decreaseSpeed();
            if (vm.VM_playSpeed < 0.1)
            {
                t_playSpeed.Text = "0";
            }
        }

        private void b_pause_Click(object sender, RoutedEventArgs e)
        {
            vm.Pause();
        }

        private void b_play_Click(object sender, RoutedEventArgs e)
        {
            vm.Play();
        }

        private void b_speedUp_Click(object sender, RoutedEventArgs e)
        {
            vm.increaseSpeed();
        }

        private void b_end_Click(object sender, RoutedEventArgs e)
        {
            vm.goToEnd();
            t_progress.Text = "100%";
            progressBar.Value = vm.VM_lines;
        }

        private void SliderValueChanged(object sender, RoutedEventArgs e)
        {
            vm.skipTo(Convert.ToInt32(progressBar.Value));
            t_progress.Text = (Convert.ToInt32(vm.VM_position * 100 / vm.VM_lines)).ToString() + "%";
        }
    }
}
