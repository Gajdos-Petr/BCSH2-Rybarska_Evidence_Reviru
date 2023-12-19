using LiteDB;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.ViewModel.Edit;
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
  public  class MembersViewModel : ObservableObject
    {

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    ApplyFilter(null);
                }
            }
        }
        public static ObservableCollection<Member> Members { get; set; }

        public static ObservableCollection<Member> MemberslOriginal { get; set; }

        public RelayCommand SearchCommand { get; set; }

        private DatabaseManager<Member> DatabaseManager { get; set; }

        public Member SelectedMember { get; set; }
        public RelayCommand ShowAddWindowCommand { get; set; }

        public RelayCommand ShowEditWindowCommand { get; set; }


        public RelayCommand RemoveMemberCommand { get; set; }
        public MembersViewModel()
        {
            DatabaseManager = new DatabaseManager<Member>("members");
            Members = DatabaseManager.LoadData();
            MemberslOriginal = DatabaseManager.LoadData();
            DatabaseManager.Dispose();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            ShowEditWindowCommand = new RelayCommand(ShowEditWindow, CanShowEditWindow);
            RemoveMemberCommand = new RelayCommand(RemoveMember, CanRemoveMember);
            SearchCommand = new RelayCommand(ApplyFilter, CanApply);


        }



        private bool CanShowEditWindow(object obj)
        {
            return SelectedMember != null;
        }

        private void ShowEditWindow(object obj)
        {
            EditMemberViewModel editMemberViewModel = new EditMemberViewModel(SelectedMember);
            AddNewMember editMemberWindow = new AddNewMember { DataContext = editMemberViewModel};
            editMemberWindow.Show();
            DatabaseManager.Dispose();

        }


        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
           AddNewMemberViewModel addNewMemberViewModel = new AddNewMemberViewModel();
            AddNewMember addNewMemberWindow = new AddNewMember { DataContext = addNewMemberViewModel};
            addNewMemberWindow.Show();
            DatabaseManager.Dispose();
        }


        private bool CanRemoveMember(object obj) { return SelectedMember != null; }

        private void RemoveMember(object obj)
        {
            if (SelectedMember.Equals(LoginService.CurrentLogedMember))
            {
                MessageBox.Show("Nelze odebrat tohoto člena, protože jste za něho aktuálně přihlášen");
            }
            else
            {
                //Odebrani loginu clena
                var databaseManagerDva = new DatabaseManager<MemberLogin>("logins");
                var l = new MemberLogin { LoginIdentifier = SelectedMember.MemberId };
                databaseManagerDva.DeleteItemInDatabase(l);
                databaseManagerDva.Dispose();

                //Odebrani clena z databaze
                DatabaseManager = new DatabaseManager<Member>("members");
                DatabaseManager.DeleteItemInDatabase(SelectedMember);
                DatabaseManager.Dispose();
                //odebrani jeho loginu pro prihlaseni

                Members.Remove(SelectedMember);
            }
   



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

        private bool CanApply(object obj)
        {
            return true;
        }

        private void ApplyFilter(object obj)
        {
            if (SearchText.Length == 0)
            {
                Members.Clear() ;
                foreach (var item in MemberslOriginal)
                {
                    Members.Add(item);
                }
            }
            else
            {

                
                var filteredGrounds = Members
                .Where(item => item.LastName.Contains(SearchText))
    .ToList();

                Members.Clear();
                foreach (var item in filteredGrounds)
                {
                    Members.Add(item);
                }

            }


        }
    }
}
