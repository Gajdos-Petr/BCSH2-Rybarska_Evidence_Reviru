using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand GroundsViewCommand { get; set; }

        public RelayCommand MemberInformationViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public GroundsViewModel GroundsVM { get; set; }


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
            HomeVM = new HomeViewModel();
            GroundsVM = new GroundsViewModel();
            MemberInformationVM = new MemberInformationViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(delegate
            {
                CurrentView = HomeVM;
            });

            MemberInformationViewCommand = new RelayCommand(delegate
            {
                CurrentView = MemberInformationVM;
            });

            GroundsViewCommand = new RelayCommand(delegate
            {
                CurrentView = GroundsVM;
            });


        }

        public Visibility AdminButtonsVisibility
        {
            get { return MemberInformationViewModel.CurrentLogedMember.MemberType is MemberType.Admin ? Visibility.Visible : Visibility.Collapsed; }
        }
    }
}
