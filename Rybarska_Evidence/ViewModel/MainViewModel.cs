
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


        //public HomeViewModel HomeVM { get; set; }


        public GroundsViewModel GroundsVM { get; set; }


        public MembersViewModel MembersVM { get; set; }

        public MemberInformationViewModel MemberInformationVM { get; set; }


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

            MembersViewCommand = new RelayCommand(o =>
            {
                MembersVM = new MembersViewModel();
                CurrentView = MembersVM;

            }, _ => true);
        }

        public  Visibility AdminButtonsVisibility
        {
            get { return MemberInformationViewModel.CurrentLogedMember.MemberType is MemberType.Vedeni ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
