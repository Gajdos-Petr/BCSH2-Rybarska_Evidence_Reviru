using LiteDB;
using Rybarska_Evidence.Core;
using Rybarska_Evidence.Db;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.ViewModel
{
    public class AddNewGroundViewModel
    {

        public RelayCommand AddNewGroundCommand {  get; set; }
       // private DatabaseManager<FishingGrounds> databate;


        public RelayCommand TestCommand { get; set; }

        public AddNewGroundViewModel()
        {
            AddNewGroundCommand = new RelayCommand(AddNewGround, CanAddNewGround);

        }

        private bool CanAddNewGround(object obj)
        {
            return true;
        }

        private void AddNewGround(object obj)
        {
            //   FishingGrounds addGround = new FishingGrounds { Number = 111, Name = "Labe 24", PositionNumber = 1, PositionName = "Kolák", GeoundsType = GeoundsType.Mimopstruhovy, Size = 34.5, Description = "popis ktery poitom domyslim" };
            //  databate.AddNewItemToCollection(addGround);
            //using (var db = new LiteDatabase("Database/FishingData.db"))
            //{
            //    FishingGrounds addGround = new FishingGrounds { Number = 111, Name = "Labe 24", PositionNumber = 1, PositionName = "Kolák", GeoundsType = GeoundsType.Mimopstruhovy, Size = 34.5, Description = "popis ktery poitom domyslim" };
            //    Member newMember = new Member
            //    {
            //        MemberId = 1,
            //        FirstName = "Kamil",
            //        LastName = "Vocas",
            //        DateOfBirth = DateTime.Now,
            //        MemberType = MemberType.Vedeni,
            //        Document = new Document
            //        {
            //            License = DateTime.Now,
            //            Sticker = false,
            //            TypeOfPermit = PermitType.Mistni
            //        }
            //    };
            //    var col = db.GetCollection<Member>("members");


            //    col.Insert(newMember);
            //}
        }

        private bool CanTest(object obj)
        {
            return true;
        }

      
    }
}
