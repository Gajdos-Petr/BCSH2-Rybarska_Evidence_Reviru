using Rybarska_Evidence.Core;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel
{
  public class GroundsViewModel : ObservableObject
    {


        public ObservableCollection<FishingGrounds> FishingGroundsColl { get; set; }
        public GroundsViewModel()
        {
            FishingGroundsColl = new ObservableCollection<FishingGrounds>() { new FishingGrounds { Number = 411035, Name = "Labe 21", PositionNumber = 2, PositionName = "Katlov", GeoundsType = GeoundsType.Mimopstruhovy, Size = 34, Description = "Kraty pospius" } };

        }

        public GroundsViewModel GroundsVM { get; set; }




    }
}
