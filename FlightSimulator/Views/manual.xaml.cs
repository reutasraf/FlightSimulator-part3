﻿using FlightSimulator.Model.EventArgs;
using FlightSimulator.ViewModels;
using System;
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

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for manual.xaml
    /// </summary>
    public partial class manual : UserControl
    {
        public manual()
        {
            InitializeComponent();
            this.DataContext = new viewModelJoiystick();
        }

        private void Joys_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SliderRudder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
