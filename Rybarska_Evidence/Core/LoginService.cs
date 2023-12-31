using Rybarska_Evidence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Core
{
   public sealed class LoginService
    {

        private static LoginService instance;
        public static Member CurrentLogedMember { get; set; }

        public static string Password { get; set; }

        public LoginService(Member loged)
        {

            CurrentLogedMember = loged;   
           
        }




        //public static LoginService Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new LoginService();
        //        }
        //        return instance;
        //    }
        //}

        //public Member CurrentLogedMember
        //{
        //    get { return currentLogedMember; }
        //    set
        //    {
        //        if (currentLogedMember != value)
        //        {
        //            currentLogedMember = value;
        //            OnCurrentLogedMemberChanged?.Invoke(this, EventArgs.Empty);
        //        }
        //    }
        //}

        //public event EventHandler OnCurrentLogedMemberChanged;

    }
}
