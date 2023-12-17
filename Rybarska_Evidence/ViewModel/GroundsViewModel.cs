using LiteDB;
using Microsoft.VisualBasic;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.ViewModel;
using Rybarska_Evidence.ViewModel.Edit;
using Rybarska_Evidence.Views;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;

namespace Rybarska_Evidence.ViewModel
{
  public class GroundsViewModel : ObservableObject
    {

        public RelayCommand ShowAddWindowCommand { get; set; }

        public RelayCommand ShowEditWindowCommand { get; set; }

        private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }
     
        public  FishingGrounds SelectedGround { get; set; }


        public static ObservableCollection<FishingGrounds> FishingGroundsColl { get; set; }

        public RelayCommand RemoveGroundCommand { get; set; }
        public GroundsViewModel()
        {
            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");
            FishingGroundsColl = DatabaseManager.LoadData();
            DatabaseManager.Dispose();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            RemoveGroundCommand = new RelayCommand(RemoveGround, CanRemoveGround);
            ShowEditWindowCommand = new RelayCommand(ShowEditWindow, CanShowEditWindow);


        }

        private bool CanShowEditWindow(object obj)
        {
            return SelectedGround != null;
        }
        private void ShowEditWindow(object obj)
        {
            EditGroundViewModel editGroundViewModel = new  EditGroundViewModel(SelectedGround);
            AddEditGround addEditGroundWindow = new AddEditGround { DataContext = editGroundViewModel };
            addEditGroundWindow.Show();
            DatabaseManager.Dispose();
        }


        private void ClearBoxes() { 
        }
        public GroundsViewModel GroundsVM { get; set; }

        private bool CanShowAddWindow(object obj)
        {
            return true;
        }
        private void ShowAddWindow(object obj)
        {
            AddNewGroundViewModel addNewGroundViewModel = new AddNewGroundViewModel();
            AddEditGround addEditGroundWindow = new AddEditGround { DataContext = addNewGroundViewModel};
            addEditGroundWindow.Show();
            DatabaseManager.Dispose();
        }


        private bool CanRemoveGround(object obj) { return SelectedGround != null; }

       
        private void RemoveGround(object obj)
        {

            //Odebrani clena z databaze
            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");
            DatabaseManager.DeleteItemInDatabase(SelectedGround);
            DatabaseManager.Dispose();

            FishingGroundsColl.Remove(SelectedGround);


        }





        public Visibility AdminButtonsVisibility
        {
            get { return MemberInformationViewModel.CurrentLogedMember.MemberType is MemberType.Vedeni ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}


