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

namespace PTI_Ear_Trainer.View
{
    /// <summary>
    /// Interaction logic for Howtoplay.xaml
    /// </summary>
    public partial class Howtoplay : Window
    {
        public Howtoplay()
        {
            InitializeComponent();
            Description.Text = "";
        }
        
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
