using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rybarska_Evidence.ViewModel
{
  public  class MembersViewModel
    {
  

        public ObservableCollection<Member> Members { get; set; }

        private DatabaseManager<Member> DatabaseManager { get; set; }


        public RelayCommand ShowAddWindowCommand { get; set; }

        public MembersViewModel()
        {
            DatabaseManager = new DatabaseManager<Member>("members");
            Members = DatabaseManager.LoadData();
            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
        }


        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
            AddNewMember addNewMemberWindow = new AddNewMember();
            addNewMemberWindow.Show();
        }
    }
}
