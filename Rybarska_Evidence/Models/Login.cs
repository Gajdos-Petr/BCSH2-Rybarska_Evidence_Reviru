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

    public class Login
    {
        public int UserID { get; set; }
        public string Password { get; set; }

        public override string? ToString()
        {
            return UserID.ToString() + " " + Password;
        }

        // public LoginType LoginType { get; set; }



    }
}
