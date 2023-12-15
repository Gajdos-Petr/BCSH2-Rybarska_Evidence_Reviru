using LiteDB;
using Microsoft.VisualBasic;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.ViewModel;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Rybarska_Evidence.ViewModel
{
  public class GroundsViewModel : ObservableObject
    {

        public RelayCommand ShowAddWindowCommand { get; set; }
     private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }

        public static ObservableCollection<FishingGrounds> FishingGroundsColl { get; set; }
        public GroundsViewModel()
        {
            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");
            FishingGroundsColl = DatabaseManager.LoadData();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);


        }

        public GroundsViewModel GroundsVM { get; set; }

        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
            AddNewGround addNewGroundWindow = new AddNewGround();
            addNewGroundWindow.Show();
        }


    }
}


