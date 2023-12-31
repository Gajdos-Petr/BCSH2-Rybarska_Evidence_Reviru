using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel.Edit
{
    public class AddNewCatchViewModel : ObservableObject
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


        public RelayCommand AddCatchCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        private DatabaseManager<Catch> DatabaseManager { get; set; }


        public List<int> GroundNames { get; set; }
        public List<string> FishNames { get; set; }

        public Catch SelectedCatch { get; set; }

        public AddNewCatchViewModel()
        {
            GroundNames = LoadGroundNames();

            AddCatchCommand = new RelayCommand(AddNewCatch, CanAddNewCatch);
            SelectedCatch = new Catch { Visit = DateTime.Now, MemberId = LoginService.CurrentLogedMember.MemberId, FishOne = new Carry { FishName = "-", Lenght = 0, Weight = 0 }, FishTwo = new Carry { FishName = "-", Lenght = 0, Weight = 0 } };
   
            FishNames = new List<string> { "Kapr", "Cejn", "Štika", "Amur", "Sumec", "Pstruh", "Úhoř"};
            CancelCommand = new RelayCommand(CancelWindow, CanCancel);
            DatabaseManager = new DatabaseManager<Catch>("catches");
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
        private bool CanAddNewCatch(object obj)
        {
            return true;
        }

        private void AddNewCatch(object obj)
        {

            if (CheckCatchInformation())
            {
                //pridani do listu
                CatchViewModel.Catches.Add(new Catch
                {
                    Id = SelectedCatch.Id = DatabaseManager.FindMaxId() + 1,
                    GroundNumber = SelectedCatch.GroundNumber,
                    Visit = SelectedCatch.Visit,
                    FishOne = new Carry
                    {
                        FishName = SelectedCatch.FishOne.FishName,
                        Lenght = SelectedCatch.FishOne.Lenght,
                        Weight = SelectedCatch.FishOne.Weight
                    },
                    FishTwo = new Carry
                    {
                        FishName = SelectedCatch.FishTwo.FishName,
                        Lenght = SelectedCatch.FishTwo.Lenght,
                        Weight = SelectedCatch.FishTwo.Weight
                    },
                });

                //Pridat do databáze

                DatabaseManager.AddNewItemToDatabase(SelectedCatch);
                // ClearBoxes();
            }
            else
            {

            }

        }
        private bool CheckCatchInformation()
        {
            bool ok = true;
            if (SelectedCatch.Visit > DateTime.Now)
            {
                MessageBox.Show("Vycházka nemohla proběhnout v budoucnu!", "Chyba");
                ok = false;
            }else if (isChecked)
            {

            }

            return ok;
        }
        private void ClearBoxes()
        {
            SelectedCatch.Visit = DateTime.Now;
            SelectedCatch.FishOne.FishName = string.Empty;
            SelectedCatch.FishOne.Lenght = 0;
            SelectedCatch.FishOne.Weight = 0;
            SelectedCatch.FishTwo.FishName = string.Empty;
            SelectedCatch.FishTwo.Lenght = 0;
            SelectedCatch.FishTwo.Weight = 0;


        }

        public List<int> LoadGroundNames()
        {
            List<int> output = new List<int>();
            var db = new DatabaseManager<FishingGrounds>("grounds");
            output = db.LoadGroundNumbers(ground => ground.Number).Distinct().ToList();
            db.Dispose();
            return output;
        }
    }
}
