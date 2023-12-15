using Rybarska_Evidence.ViewModel;
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

namespace Rybarska_Evidence.Views.UserControls
{
    /// <summary>
    /// Interakční logika pro AddNewGround.xaml
    /// </summary>
    public partial class AddNewGround : Window
    {
        public AddNewGround()
        {
            InitializeComponent();
            AddNewGroundViewModel addNewGroundViewModel = new AddNewGroundViewModel();
            DataContext = addNewGroundViewModel;
        }
    }
}
