using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
    public class Item
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    public class MemberStatsViewModel
    {
        public ObservableCollection<Item> Items { get; set; }

        public ObservableCollection<Carry> Carrys { get; set; }

        public StatsMember MemberStats { get; set; }

        private DatabaseManager<Visit> DatabaseManager { get; set; }


        public MemberStatsViewModel() {
            DatabaseManager = new DatabaseManager<Visit>();
         

            MemberStats = new StatsMember();
            MemberStats = DatabaseManager.GetMemberStats(LoginService.CurrentLogedMember.MemberId);
            //Carrys = DatabaseManager.GetTopThreeCatches(LoginService.CurrentLogedMember.MemberId);
     
            DatabaseManager.Dispose(); 
            
            Items = new ObservableCollection<Item>
           
        {
            new Item { Name = "První", Number = 1 },
            new Item { Name = "Druhý", Number = 2 },
            // Další položky podle potřeby
        };
        }
    }
}
