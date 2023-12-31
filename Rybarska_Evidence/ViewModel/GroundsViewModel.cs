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
using System.Windows.Input;
using static System.Formats.Asn1.AsnWriter;

namespace Rybarska_Evidence.ViewModel
{
  public class GroundsViewModel : ObservableObject
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


        public RelayCommand SearchCommand { get; set; }

        public RelayCommand ShowAddWindowCommand { get; set; }

        public RelayCommand ShowEditWindowCommand { get; set; }

        public RelayCommand ShowInfoWindowCommand { get; set; }

        public RelayCommand ShowMapCommand { get; set; }

        private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }
     
        public  FishingGrounds SelectedGround { get; set; }


        public static ObservableCollection<FishingGrounds> FishingGroundsColl { get; set; }
        public static ObservableCollection<FishingGrounds> FishingGroundsCollOriginal { get; set; }

        public RelayCommand RemoveGroundCommand { get; set; }
        public GroundsViewModel()
        {
            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");
            FishingGroundsColl = DatabaseManager.LoadData();
            FishingGroundsCollOriginal = DatabaseManager.LoadData();
            DatabaseManager.Dispose();

            ShowAddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            RemoveGroundCommand = new RelayCommand(RemoveGround, CanRemoveGround);
            ShowEditWindowCommand = new RelayCommand(ShowEditWindow, CanShowEditWindow);
            ShowInfoWindowCommand = new RelayCommand(ShowInfo, CanShowEditWindow);
            SearchCommand = new RelayCommand(ApplyFilter, CanApply);
            ShowMapCommand = new RelayCommand(ShowMap, CanShowEditWindow);
        }

        private  void ShowMap(object obj)
        {
            MessageBox.Show("Vynegerovaná trasa bude vytvořena na základně vaší adresy bydliště.", "Informace");
            //string mapUrl = $"https://www.openstreetmap.org/?mlat={SelectedGround.GeoLocations.Latitude.ToString("0.#####", System.Globalization.CultureInfo.InvariantCulture)}&mlon={SelectedGround.GeoLocations.Longitude.ToString("0.#####", System.Globalization.CultureInfo.InvariantCulture)}#map=15/{SelectedGround.GeoLocations.ToString()}";
            string mapUrl = $"https://www.openstreetmap.org/directions?from={LoginService.CurrentLogedMember.Adress}&to={SelectedGround.GeoLocations.ToString()}";
        
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = mapUrl,
                UseShellExecute = true
            });
        }





        private void ShowInfo(object obj)
        {
            MessageBox.Show(SelectedGround.ToString(), "Informace o revíru");
        }



        private bool CanApply(object obj)
        {
            return true;
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




        private void ApplyFilter(object obj)
        {
            if (SearchText.Length == 0)
            {
                //FishingGroundsColl = FishingGroundsCollOriginal;
                FishingGroundsColl.Clear();
                foreach (var item in FishingGroundsCollOriginal)
                {
                    FishingGroundsColl.Add(item);
                }
            }
            else
            {

                int text = int.Parse(SearchText);
                var filteredGrounds = FishingGroundsColl
                .Where(item => item.Number.ToString().Contains(text.ToString()))
    .ToList();

                FishingGroundsColl.Clear();
                foreach (var item in filteredGrounds)
                {
                    FishingGroundsColl.Add(item);
                }

            }


        }



    }
}


