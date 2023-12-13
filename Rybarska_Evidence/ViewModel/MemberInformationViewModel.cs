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
                DateOfBirth = new DateTime(1999, 10, 12),
                MemberType = MemberType.Regular,
                Document = new Document
                {
                    License = new DateTime(),
                    Sticker = false,
                    TypeOfPermit = PermitType.Mistni
                }
            };
        }

        public static Member CurrentLogedMember { get; set; }

     
    }
}
