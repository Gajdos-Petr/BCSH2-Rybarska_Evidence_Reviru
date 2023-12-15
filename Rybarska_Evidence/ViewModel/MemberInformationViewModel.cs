using Rybarska_Evidence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.ViewModel
{
  public  class MemberInformationViewModel
    {
      
        public MemberInformationViewModel()

        {

            CurrentLogedMember = new Member
            {
                MemberId = 1,
                FirstName = "Kamil",
                LastName = "Vocas",
                DateOfBirth = DateTime.Now,
                MemberType = MemberType.Vedeni,
                Document = new Document
                {
                    License = DateTime.Now,
                    Sticker = false,
                    TypeOfPermit = PermitType.Mistni
                }
            };
        }

        public static Member CurrentLogedMember { get; set; }

     
    }
}
