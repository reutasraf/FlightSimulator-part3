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
using System.Windows.Shapes;
using FlightSimulator.Model;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine("connect");
            InitializeComponent();
           // Command c = new Command();
           // c.connectServer();
           // Server s = new Server();
            //s.connectServer();
        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Auto_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
