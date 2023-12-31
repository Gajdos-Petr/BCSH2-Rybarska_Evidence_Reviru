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

        public Member SelectedMember { get; set; }

        public RelayCommand AddNewMemberCommand { get; set; }
        
        public RelayCommand CancelAddNewMemberCommand { get; set; }

        private DatabaseManager<Member> DatabaseManager { get; set; }
        public AddNewMemberViewModel()
        {
            AddNewMemberCommand = new RelayCommand(AddNewMember, CanAddNewMember);
            CancelAddNewMemberCommand = new RelayCommand(CancelWindow, CanCancel);
            Permits = Enum.GetValues(typeof(PermitType)).Cast<PermitType>().ToList();
            TypesMembers = Enum.GetValues(typeof(MemberType)).Cast<MemberType>().ToList();
            StickerChoose = new List<bool> { true, false };
            DatabaseManager = new DatabaseManager<Member>("members");

            SelectedMember = new Member { DateOfBirth = DateTime.Now, Document = new Document {License = DateTime.Now } };
        }
        
        private bool CanAddNewMember(object obj)
        {
            //bool can;
            //if (!DateOfBirth())
            //{
            //    MessageBox.Show("Datum blbe");
            //    can = false;
            //}
            //else
            //{
            //    can = true;
            //}
            //return can;
            //MessageBox.Show("aktualni: " + DateTime.Now.ToString());
            //// Ověření, zda jsou vyplněna povinná pole a správná data
            bool isFirstNameValid = !string.IsNullOrEmpty(SelectedMember.FirstName);
           bool isLastNameValid = !string.IsNullOrEmpty(SelectedMember.LastName);
            bool iiAdressValid = !string.IsNullOrEmpty(SelectedMember.Adress);

            return isFirstNameValid && isLastNameValid;

            //bool isLicenseValid = SelectedMember.DateOfBirth > DateTime.Now;

            //return isFirstNameValid && isLastNameValid && isDateOfBirthValid && isLicenseValid;

        }

        private bool DateOfBirth()
        {
            bool isDateOfBirthValid;
            MessageBox.Show("vybrane: " + SelectedMember.DateOfBirth.ToString());
            MessageBox.Show("aktualni: " + DateTime.Now.ToString());

            if ( SelectedMember.DateOfBirth < DateTime.Now)
            {
                isDateOfBirthValid = true;
            }
            else
            {
                isDateOfBirthValid = false;
            }
            return isDateOfBirthValid;
        }
        private void AddNewMember(object obj)
        {


            if (CheckMemberInformation())
            {
                MembersViewModel.Members.Add(new Member
                {
                    MemberId = SelectedMember.MemberId = DatabaseManager.FindMaxId() + 1,
                    FirstName = SelectedMember.FirstName,
                    LastName = SelectedMember.LastName,
                    DateOfBirth = SelectedMember.DateOfBirth,
                    MemberType = SelectedMember.MemberType,
                    Document = new Document
                    {
                        License = SelectedMember.Document.License,
                        Sticker = SelectedMember.Document.Sticker,
                        TypeOfPermit = SelectedMember.Document.TypeOfPermit
                    }
                });
                //Pridat do databáze
                DatabaseManager.AddNewItemToDatabase(SelectedMember);
                ClearBoxes();
            }

        }


       private bool CheckMemberInformation()
        {
            bool ok = true;
            if (SelectedMember.DateOfBirth >= DateTime.Now)
            {
                MessageBox.Show("Datum narození nemůže být větší nebo stejný jako aktuální datum!", "Chyba");
                ok = false;
            }
            else if (SelectedMember.Document.License < DateTime.Now)
            {
                MessageBox.Show("Rybářský lístek je propadlý!", "Chyba");

                ok = false;

            }

            return ok;
        }

        private void ClearBoxes()
        {
            SelectedMember.FirstName = "";
            SelectedMember.LastName = "";
            SelectedMember.DateOfBirth = DateTime.Now;
            SelectedMember.MemberType = MemberType.Clen;
            SelectedMember.Document.License = DateTime.Now;
            SelectedMember.Document.Sticker = false;
            SelectedMember.Document.TypeOfPermit = PermitType.Mistni;

      
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

        public List<PermitType> Permits { get; set; }

        public List<MemberType> TypesMembers { get; set; }

        public List<bool> StickerChoose { get; set; }



    }
}
