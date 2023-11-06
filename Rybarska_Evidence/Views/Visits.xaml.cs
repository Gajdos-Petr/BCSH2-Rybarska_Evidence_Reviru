using Rybarska_Evidence.Models;
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
using System.Windows.Shapes;

namespace Rybarska_Evidence.Views
{
    /// <summary>
    /// Interakční logika pro Visits.xaml
    /// </summary>
    public partial class Visits : Window
    {
        public Visits()
        {
            InitializeComponent();
            List<Visit> listOfVisits = new List<Visit>();
            listOfVisits.Add(new Visit() { MemberId = 1, GroundId = 411035, SecondIdOfGround = 2, DateVisit = null, Cought = false });
            lvVisits.ItemsSource = listOfVisits;
        }
    }
}
