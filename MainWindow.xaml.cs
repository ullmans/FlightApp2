﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.ComponentModel;

namespace test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ControlBarViewModel vm;
        //public bool running;
        //private int steps, place, playSpeed, progress;

        public MainWindow()
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
            t_playSpeed.Text = (vm.VM_playSpeed / 10).ToString() + "."
                + (vm.VM_playSpeed % 10).ToString();
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
            t_playSpeed.Text = (vm.VM_playSpeed / 10).ToString() + "."
                + (vm.VM_playSpeed % 10).ToString();
        }

        private void b_end_Click(object sender, RoutedEventArgs e)
        {
            vm.goToEnd();
            t_progress.Text = "100%";
            progressBar.Value = vm.VM_steps;
        }

        private void SliderValueChanged(object sender, RoutedEventArgs e)
        {
            vm.skipTo(Convert.ToInt32(progressBar.Value));
            t_progress.Text = (Convert.ToInt32(vm.VM_position * 100 / vm.VM_steps)).ToString() + "%";
        }

        private void b_move_Click(object sender, RoutedEventArgs e)
        {
            vm.move();
        }
    }
}