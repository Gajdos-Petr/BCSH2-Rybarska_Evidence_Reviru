using Rybarska_Evidence.Core;
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


            //CurrentLogedMember = new Member
            //{
            //    MemberId = 1,
            //    FirstName = "emilk",
            //    LastName = "pom",
            //    DateOfBirth = DateTime.Now,
            //    MemberType = MemberType.Vedeni,
            //    Document = new Document
            //    {
            //        License = DateTime.Now,
            //        Sticker = false,
            //        TypeOfPermit = PermitType.Mistni
            //    }
            //};
            CurrentLogedMember = new Member
            {
                MemberId = LoginService.CurrentLogedMember.MemberId,
                FirstName = LoginService.CurrentLogedMember.FirstName,
                LastName = LoginService.CurrentLogedMember.LastName,
                DateOfBirth = LoginService.CurrentLogedMember.DateOfBirth,
                MemberType = LoginService.CurrentLogedMember.MemberType,
                Document = new Document
                {
                    License = LoginService.CurrentLogedMember.Document.License,
                    Sticker = LoginService.CurrentLogedMember.Document.Sticker,
                    TypeOfPermit = LoginService.CurrentLogedMember.Document.TypeOfPermit
                }
            };
        }

        public static Member CurrentLogedMember { get; set; }

     
    }
}
