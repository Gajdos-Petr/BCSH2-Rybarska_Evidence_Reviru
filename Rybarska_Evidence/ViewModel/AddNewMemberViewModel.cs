using Rybarska_Evidence.Core;
using Rybarska_Evidence.Model;
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
    public class AddNewMemberViewModel
    {

        public Member NewMemberToAdd { get; set; }

        public RelayCommand AddNewMemberCommand { get; set; }
        public AddNewMemberViewModel()
        {
            AddNewMemberCommand = new RelayCommand(AddNewMember, CanAddNewMember);
            Permits = Enum.GetValues(typeof(PermitType)).Cast<PermitType>().ToList();
             NewMemberToAdd = new Member{ DateOfBirth = DateTime.Now };
        }

        private bool CanAddNewMember(object obj)
        {
            return true;
        }


        private void AddNewMember(object obj)
        {
            MessageBox.Show(NewMemberToAdd.Document.TypeOfPermit.ToString());
        }
        public List<PermitType> Permits { get; set; }



    }
}
