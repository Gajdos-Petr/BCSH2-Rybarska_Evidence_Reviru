using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.ViewModel.Edit;
using Rybarska_Evidence.Views;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
    public class CatchViewModel
    {

        public RelayCommand ShowAddWindowCommand { get; set; }

        public RelayCommand RemoveCatchCommand { get; set; }

        private DatabaseManager<Catch> DatabaseManager { get; set; }

        public Catch SelectedCatch { get; set; }

        public static ObservableCollection<Catch> Catches { get; set; }





        public CatchViewModel()
        {
            DatabaseManager = new DatabaseManager<Catch>("catches");
            Catches = DatabaseManager.LoadCatches(LoginService.CurrentLogedMember.MemberId);
            DatabaseManager.Dispose();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            RemoveCatchCommand = new RelayCommand(RemoveCatch, CanRemoveCatch);

        }


        private bool CanRemoveCatch(object obj) { return SelectedCatch != null; }


        private void RemoveCatch(object obj)
        {

            //Odebrani clena z databaze
            DatabaseManager = new DatabaseManager<Catch>("catches");
            DatabaseManager.DeleteItemInDatabase(SelectedCatch);
            DatabaseManager.Dispose();

            Catches.Remove(SelectedCatch);


        }

        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
         
            AddNewCatchViewModel addNewCatchViewModel = new AddNewCatchViewModel();
            AddEditCatch addEditCatchWindow = new AddEditCatch { DataContext = addNewCatchViewModel };
            addEditCatchWindow.Show();
            DatabaseManager.Dispose();
        }




    }
}
