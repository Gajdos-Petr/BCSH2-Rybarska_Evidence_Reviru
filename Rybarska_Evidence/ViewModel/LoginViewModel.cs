using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
   public class LoginViewModel
    {
        Database databaseManager = new Database();



        public RelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            var loginRepository = new DatabaseManager<Login>(databaseManager.GetDatabaseInstance(), "logins");
            var loaded = loginRepository.GetAll();
            foreach (var item in loaded)
            {
                MessageBox.Show(item.ToString());
            }
            //var newLogin = new Login
            //    {UserID = 1, Password = "Heslo" };
            //loginRepository.Add(newLogin);

        }

        //private void OnLogin()
        //{


    }
}
