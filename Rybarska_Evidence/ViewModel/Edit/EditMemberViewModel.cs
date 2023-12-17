using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel.Edit
{
    public class EditMemberViewModel
    {

        public Member SelectedMember { get; set; }
        private DatabaseManager<Member> DatabaseManager { get; set; }
        public RelayCommand CancelAddNewMemberCommand { get; set; }

        public RelayCommand AddNewMemberCommand { get; set; }

        public EditMemberViewModel(Member memberForEdit)
        {
            AddNewMemberCommand = new RelayCommand(AddNewMember, CanAddNewMember);
            CancelAddNewMemberCommand = new RelayCommand(CancelWindow, CanCancel);
            Permits = Enum.GetValues(typeof(PermitType)).Cast<PermitType>().ToList();
            TypesMembers = Enum.GetValues(typeof(MemberType)).Cast<MemberType>().ToList();
            SelectedMember = memberForEdit;
        }
        private bool CanAddNewMember(object obj)
        {
            return true;
        }


        private void AddNewMember(object obj)
        {

            DatabaseManager = new DatabaseManager<Member>("members");
            DatabaseManager.UpdateItemInDatabase(SelectedMember);
            DatabaseManager.Dispose();
        }


        private bool CanCancel(object obj)
        {
            return true;
        }

        private void CancelWindow(object obj)
        {
            //  DatabaseManager.Dispose();
            App.Current.Windows[1].Close();


        }
        public List<PermitType> Permits { get; set; }

        public List<MemberType> TypesMembers { get; set; }

    }
}
