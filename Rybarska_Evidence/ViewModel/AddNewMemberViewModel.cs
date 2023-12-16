using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
    public class AddNewMemberViewModel
    {

        public Member NewMemberToAdd { get; set; }

        public RelayCommand AddNewMemberCommand { get; set; }
        
        public RelayCommand CancelAddNewMemberCommand { get; set; }

        private DatabaseManager<Member> DatabaseManager { get; set; }
        public AddNewMemberViewModel()
        {
            AddNewMemberCommand = new RelayCommand(AddNewMember, CanAddNewMember);
            CancelAddNewMemberCommand = new RelayCommand(CancelWindow, CanCancel);
            Permits = Enum.GetValues(typeof(PermitType)).Cast<PermitType>().ToList();
            TypesMembers = Enum.GetValues(typeof(MemberType)).Cast<MemberType>().ToList();
            DatabaseManager = new DatabaseManager<Member>("members");

            NewMemberToAdd = new Member { DateOfBirth = DateTime.Now, Document = new Document {License = DateTime.Now } };
        }

        private bool CanAddNewMember(object obj)
        {
            // Ověření, zda jsou vyplněna povinná pole
            bool isFirstNameValid = !string.IsNullOrEmpty(NewMemberToAdd.FirstName);
            bool isLastNameValid = !string.IsNullOrEmpty(NewMemberToAdd.LastName);
            //bool isDateOfBirthValid = NewMemberToAdd.DateOfBirth.;
            //bool isLicenseValid = NewMemberToAdd.Document.License.HasValue;
           // bool isPermitTypeValid = NewMemberToAdd.Document.TypeOfPermit != PermitType.Zadna; // Upravte podle vašich pravidel

            // Logika pro ověření dalších podmínek

            // Celkové zhodnocení, zda můžete přidat nového člena
            return isFirstNameValid && isLastNameValid ;
        }


        private void AddNewMember(object obj)
        {

            //MessageBox.Show(NewMemberToAdd.Document.TypeOfPermit.ToString());
            MembersViewModel.Members.Add(new Member {
                MemberId = NewMemberToAdd.MemberId = DatabaseManager.FindMaxId() + 1,
                FirstName = NewMemberToAdd.FirstName, 
                LastName = NewMemberToAdd.LastName, 
                DateOfBirth = NewMemberToAdd.DateOfBirth,
                MemberType = NewMemberToAdd.MemberType,
                Document = new Document
                {
                    License = NewMemberToAdd.Document.License,
                    Sticker = NewMemberToAdd.Document.Sticker,
                    TypeOfPermit = NewMemberToAdd.Document.TypeOfPermit
                }
            });
            //Pridat do databáze
           DatabaseManager.AddNewItemToDatabase(NewMemberToAdd);
            DatabaseManager.Dispose();
        }


        private bool CanCancel(object obj)
        {
            return true;
        }

        private void CancelWindow(object obj)
        {

        }

        public List<PermitType> Permits { get; set; }

        public List<MemberType> TypesMembers { get; set; }


    }
}
