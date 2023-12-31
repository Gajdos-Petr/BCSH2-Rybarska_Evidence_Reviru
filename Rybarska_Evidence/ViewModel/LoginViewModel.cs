using LiteDB;
using Microsoft.VisualBasic;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;

namespace Rybarska_Evidence.ViewModel
{
    public class LoginViewModel
    {
        public MemberLogin NewLogin { get; set; }

        public RelayCommand LoginCommand { get; }

        private  ILiteCollection<MemberLogin> col;

        private DatabaseManager<MemberLogin> DatabaseManager { get; set; }
        public LoginViewModel()
        {

            LoginCommand = new RelayCommand(OnLogin, CanLogin);
            NewLogin = new MemberLogin();
        }

        private void OnLogin(object obj)
        {
            DatabaseManager = new DatabaseManager<MemberLogin>("logins");
       
            bool isIn = DatabaseManager.IsInDatabase(NewLogin);
            DatabaseManager.Dispose();
            if (isIn)
            {
                DatabaseManager<Member> db = new DatabaseManager<Member>("members");
                LoginService.CurrentLogedMember = db.GetItemFromDatabase(NewLogin.LoginIdentifier);
                LoginService.Password = NewLogin.Password;
                db.Dispose();
                MainApp mainApp = new MainApp();
                mainApp.Show();
                App.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Chybné přihlašovací údaje", "Chyba při přihlášení");
            }


        }

     
        private bool CanLogin(object obj)
        {
            return NewLogin.LoginIdentifier > 0 && !string.IsNullOrEmpty(NewLogin.Password);
        }
    }
}
