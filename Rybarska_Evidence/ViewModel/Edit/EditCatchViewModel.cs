using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel.Edit
{
   public class EditCatchViewModel : ObservableObject
    {


        private bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public Catch SelectedCatch { get; set; }

        private DatabaseManager<Catch> DatabaseManager { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public RelayCommand AddCatchCommand { get; set; }

        public List<int> GroundNames { get; set; }
        public List<string> FishNames { get; set; }

        public EditCatchViewModel(Catch catchForEdit)
        {
            GroundNames = LoadGroundNames();
            FishNames = new List<string> { "Kapr", "Cejn", "Štika", "Amur", "Sumec", "Pstruh", "Úhoř" };
            SelectedCatch = catchForEdit;
            AddCatchCommand = new RelayCommand(AddEditedCatch, CanAddEdited);
            CancelCommand = new RelayCommand(CancelWindow, CanCancel);
            WasCatch();
        }


        public List<int> LoadGroundNames()
        {
            List<int> output = new List<int>();
            var db = new DatabaseManager<FishingGrounds>("grounds");
            output = db.LoadGroundNumbers(ground => ground.Number).Distinct().ToList();
            db.Dispose();
            return output;
        }

        private bool CanAddEdited(object obj)
        {
            return true;
        }


        private void AddEditedCatch(object obj)
        {

            DatabaseManager = new DatabaseManager<Catch>("catches");
            DatabaseManager.UpdateItemInDatabase(SelectedCatch);
            DatabaseManager.Dispose();

        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private void CancelWindow(object obj)
        {
            App.Current.Windows[1].Close();

        }


        private void WasCatch()
        {
            if (SelectedCatch.FishOne.Weight != 0 || SelectedCatch.FishTwo.Weight != 0)
            {
                isChecked = true;
            }
        }
    }
}
