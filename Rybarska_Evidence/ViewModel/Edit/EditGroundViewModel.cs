using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel.Edit
{
    public class EditGroundViewModel
    {

        public FishingGrounds SelectedGround {  get; set; }

        private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public RelayCommand AddGroundCommand { get; set; }


        public List<GeoundsType> GroundTypes { get; set; }

        public EditGroundViewModel(FishingGrounds groundForEdit)
        {
            GroundTypes = Enum.GetValues(typeof(GeoundsType)).Cast<GeoundsType>().ToList();
            AddGroundCommand = new RelayCommand(AddEditedGround, CanAddNewGround);
            CancelCommand = new RelayCommand(CancelWindow, CanCancel);
            SelectedGround = groundForEdit;

        }
        private bool CanCancel(object obj)
        {
            return true;
        }

        private void CancelWindow(object obj)
        {
            App.Current.Windows[1].Close();

        }
        private bool CanAddNewGround(object obj)
        {
            return true;
        }


        private void AddEditedGround(object obj)
        {

            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");
            DatabaseManager.UpdateItemInDatabase(SelectedGround);
            DatabaseManager.Dispose();
            
        }


    }
}
