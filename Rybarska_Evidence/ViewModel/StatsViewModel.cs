using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel
{
    public class StatsViewModel
    {

        public  ObservableCollection<Stats> Stats { get; set; }


        public Stats Stat { get; set; }

        private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }

        public StatsViewModel()
        {
            //Stats = DatabaseManager.GetStatsForGrounds();
            //DatabaseManager.Dispose();
        }
    }
}
