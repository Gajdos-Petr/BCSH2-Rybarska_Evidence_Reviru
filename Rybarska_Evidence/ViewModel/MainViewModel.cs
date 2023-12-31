
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
   public class MainViewModel : ObservableObject
    {
        //public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand GroundsViewCommand { get; set; }

        public RelayCommand MembersViewCommand { get; set; }

        public RelayCommand MemberInformationViewCommand { get; set; }

        public RelayCommand CatchesViewCommand { get; set; }

        public RelayCommand StatsViewCommand { get; set; }

        public RelayCommand MemberStatsViewCommand { get; set; }


        public string CurrentFishTime { get; set; }
        //public HomeViewModel HomeVM { get; set; }


        public GroundsViewModel GroundsVM { get; set; }


        public MembersViewModel MembersVM { get; set; }

        public MemberInformationViewModel MemberInformationVM { get; set; }

        public CatchViewModel CatchVM { get; set; }


        public StatsViewModel StatsVM { get; set; }

        public MemberStatsViewModel MemberStatsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            //HomeVM = new HomeViewModel();
           
            MemberInformationVM = new MemberInformationViewModel();
            CurrentFishTime = GetCurrentTime();


            CurrentView = MemberInformationVM;

            //HomeViewCommand = new RelayCommand(o =>
            //{
            //    CurrentView = HomeVM;
            //}, _ => true);

            MemberInformationViewCommand = new RelayCommand( o =>
            {
               
                CurrentView = MemberInformationVM;
              
            }, _ => true);


       

            GroundsViewCommand = new RelayCommand(o =>
            {
                GroundsVM = new GroundsViewModel();
                CurrentView = GroundsVM;
            }, _ => true);

            CatchesViewCommand = new RelayCommand(o =>
            {
                CatchVM = new CatchViewModel();
                CurrentView = CatchVM;

            }, _ => true);


 

            MembersViewCommand = new RelayCommand(o =>
            {
                MembersVM = new MembersViewModel();
                CurrentView = MembersVM;

            }, _ => true);


            StatsViewCommand = new RelayCommand(o =>
            {

                StatsVM = new StatsViewModel();
                CurrentView = StatsVM;

            }, _ => true);


            MemberStatsViewCommand = new RelayCommand(o =>
            {

                MemberStatsVM = new MemberStatsViewModel();
                CurrentView = MemberStatsVM;

            }, _ => true);

            //StatsViewCommand = new RelayCommand(o =>
            //{
            //    StatsVM = new StatsViewModel();
            //    CurrentView = StatsVM;

            //}, _ => true);
        }

        public  Visibility AdminButtonsVisibility
        {
            get { return MemberInformationViewModel.CurrentLogedMember.MemberType is MemberType.Vedeni ? Visibility.Visible : Visibility.Collapsed; }
        }


        private string GetCurrentTime()
        {
            string currentDateToReturn = string.Empty;
            DateTime currentDate = DateTime.Now;

            bool isAprilToSeptember = currentDate.Month >= 4 && currentDate.Month <= 9 && currentDate.Hour >= 4 && currentDate.Hour <= 24;
            bool isOctoberToMarch = currentDate.Month >= 10 || currentDate.Month <= 3 && currentDate.Hour >= 5 && currentDate.Hour <= 22;
            if (isAprilToSeptember)
            {
                currentDateToReturn = "od 4 do 24 hodin.";
            }
            else if (isOctoberToMarch)
            {
                currentDateToReturn = "od 5 do 22 hodin.";
            }
            return currentDateToReturn;
        }
    }
}
