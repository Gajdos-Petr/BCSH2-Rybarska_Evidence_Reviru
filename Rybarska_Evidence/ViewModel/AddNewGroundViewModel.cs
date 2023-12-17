using LiteDB;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
    public class AddNewGroundViewModel
    {

        public RelayCommand AddGroundCommand {  get; set; }
        private DatabaseManager<FishingGrounds> DatabaseManager { get; set; }

        public FishingGrounds SelectedGround { get; set; }
        public RelayCommand CancelCommand { get; set; }


        public List<GeoundsType> GroundTypes { get; set; }
        public AddNewGroundViewModel()
        {
            AddGroundCommand = new RelayCommand(AddNewGround, CanAddNewGround);
            GroundTypes = Enum.GetValues(typeof(GeoundsType)).Cast<GeoundsType>().ToList();
            SelectedGround = new FishingGrounds();
            CancelCommand = new RelayCommand(CancelWindow, CanCancel);
            DatabaseManager = new DatabaseManager<FishingGrounds>("grounds");

        }
        private bool CanCancel(object obj)
        {
            return true;
        }

        private void CancelWindow(object obj)
        {
            DatabaseManager.Dispose();

            App.Current.Windows[1].Close();

        }
        private bool CanAddNewGround(object obj)
        {
            return true;
        }

        private void AddNewGround(object obj)
        {
            //pridani do listu
            GroundsViewModel.FishingGroundsColl.Add(new FishingGrounds
            {

                Id = SelectedGround.Id = DatabaseManager.FindMaxId() + 1,
                Number = SelectedGround.Number,
                Name = SelectedGround.Name,
                PositionNumber = SelectedGround.PositionNumber,
                PositionName = SelectedGround.PositionName,
                GeoundsType = SelectedGround.GeoundsType,
                Size = SelectedGround.Size,
                Description = SelectedGround.Description,

            });
            //Pridat do databáze
            MessageBox.Show(SelectedGround.Id.ToString());

            DatabaseManager.AddNewItemToDatabase(SelectedGround);
            ClearBoxes();
        }

        private void ClearBoxes()
        {
            SelectedGround.Number = 0;
            SelectedGround.Name = string.Empty;
            SelectedGround.PositionNumber = 0;
            SelectedGround.PositionName = string.Empty;
            SelectedGround.GeoundsType = GeoundsType.Mimopstruhovy;
            SelectedGround.Size = 0;
            SelectedGround.Description = "";
        }


    }
}
