using LiteDB;
using Microsoft.VisualBasic;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
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
        public Login NewLogin { get; set; }

        public RelayCommand LoginCommand { get; }

        private  ILiteCollection<Login> col;
        
        public LoginViewModel()
        {
          //  loginRepository = new DatabaseManager<Login>(databaseManager.GetDatabaseInstance(), "logins");

            //LoginCommand = new RelayCommand(OnLogin, CanLogin);
            NewLogin = new Login();
        }

        private void OnLogin(object obj)
        {
            //using (var db = new LiteDatabase(@"Database/FishingDataNewTest.db"))
            //{
            //    col = db.GetCollection<Login>("logins");

            //    if (IsInDatabase())
            //    {
            //        MessageBox.Show("Je v databázi");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Není v databázi");
            //    }


                //var Login = new Login { LoginIdentifier = 1, Password = "password" };
                //col.Insert(Login);
                //var allLogins = col.FindAll();

      

            }
        }
      
        //private bool IsInDatabase()
        //{
        //    return col.Exists(Query.And(Query.EQ("LoginIdentifier", NewLogin.LoginIdentifier), Query.EQ("Password", NewLogin.Password)));
        //}
        //private bool CanLogin(object obj)
        //{
        //    return NewLogin.LoginIdentifier > 0 && !string.IsNullOrEmpty(NewLogin.Password);
        //}
    //}
}
