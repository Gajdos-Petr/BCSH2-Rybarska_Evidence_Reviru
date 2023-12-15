using Rybarska_Evidence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Models
{
    public enum LoginType
    {
        Normal,
        Admin
    }

    public class Login : ObservableObject
    {

        private int id;
        private string password;

        public int LoginIdentifier
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public override string? ToString()
        {
            return LoginIdentifier.ToString() + " " + Password;
        }

        // public LoginType LoginType { get; set; }



    }
}
