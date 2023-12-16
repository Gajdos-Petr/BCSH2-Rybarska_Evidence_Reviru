using LiteDB;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Rybarska_Evidence.ViewModel
{
  public  class MembersViewModel
    {
  

        public static ObservableCollection<Member> Members { get; set; }

        private DatabaseManager<Member> DatabaseManager { get; set; }

        public Member SelectedMember { get; set; }
        public RelayCommand ShowAddWindowCommand { get; set; }

        public RelayCommand RemoveMemberCommand { get; set; }
        public MembersViewModel()
        {
            DatabaseManager = new DatabaseManager<Member>("members");
            Members = DatabaseManager.LoadData();
            DatabaseManager.Dispose();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            RemoveMemberCommand = new RelayCommand(RemoveMember, CanRemoveMember);
        }


        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
            AddNewMember addNewMemberWindow = new AddNewMember();
            addNewMemberWindow.Show();
            DatabaseManager.Dispose();
        }


        private bool CanRemoveMember(object obj) { return SelectedMember != null; }

        private void RemoveMember(object obj)
        {
            DatabaseManager = new DatabaseManager<Member>("members");
            DatabaseManager.DeleteItemInDatabase(SelectedMember);
            DatabaseManager.Dispose();

        }

        private void CheckDatabaseStatus()
        {
            if (!IsDatabaseConnected())
            {
               ConnectDatabase();
            }
        }

        private void ConnectDatabase()
        {
            DatabaseManager = new DatabaseManager<Member>("members");
        }


        private bool IsDatabaseConnected()
        {
            return DatabaseManager != null;
        }
    }
}
