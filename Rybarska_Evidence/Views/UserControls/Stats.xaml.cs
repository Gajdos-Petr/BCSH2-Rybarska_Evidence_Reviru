﻿using Rybarska_Evidence.ViewModel;
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

namespace Rybarska_Evidence.Views.UserControls
{
    /// <summary>
    /// Interakční logika pro Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();

            StatsViewModel statsViewModel= new StatsViewModel();
            DataContext = statsViewModel;
        }
    }
}
