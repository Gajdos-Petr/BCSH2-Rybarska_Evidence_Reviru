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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rybarska_Evidence.Views.UserControls
{
    /// <summary>
    /// Interakční logika pro Members.xaml
    /// </summary>
    public partial class Members : UserControl
    {
        public Members()
        {
            InitializeComponent();
            MembersViewModel membersViewModel = new MembersViewModel();
            DataContext = membersViewModel;
        }
    }
}
