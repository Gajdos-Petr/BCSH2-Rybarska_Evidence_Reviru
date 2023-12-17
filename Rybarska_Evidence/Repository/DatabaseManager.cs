using LiteDB;
using Rybarska_Evidence.Model;
using Rybarska_Evidence.Models;
using Rybarska_Evidence.Views.UserControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rybarska_Evidence.Db
{
    public class DatabaseManager<T>
    {
        private readonly LiteDatabase db;

        private readonly ILiteCollection<T> collection;

        public DatabaseManager(string collectionName)
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            db = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Db\FishingData.db")));
      
            collection = db.GetCollection<T>(collectionName);
        }
  

        public ObservableCollection<T> LoadData()
        {
          
                return new ObservableCollection<T>(collection.FindAll());
        }

        public void AddNewItemToDatabase(T item)
        {
            Type foudnedType = typeof(T);
            switch (foudnedType.Name)
            {
                case "Member":
                    collection.Insert(item);
                    Member memberSa = item as Member;
                    var collectionLogins = db.GetCollection<Models.MemberLogin>("logins");
                    var newLogin = new Models.MemberLogin { LoginIdentifier = memberSa.MemberId, Password = "heslo" };
                    collectionLogins.Insert(newLogin);

                    break;

                case "FishingGrounds":
                    collection.Insert(item);
                    break;

                case "Catch":
                    collection.Insert(item);
                break;
            }

        }

        public void UpdateItemInDatabase(T item)
        {
               collection.Update(item);
            
        }

        public void DeleteItemInDatabase(T item)
        {

            List<T> itemList = collection.FindAll().ToList();
            collection.DeleteAll();

            foreach (var t in itemList)
            {

                switch (typeof(T).Name)
                {
                    case "FishingGrounds":

                        FishingGrounds ground = t as FishingGrounds;
                        FishingGrounds groundToRemove = item as FishingGrounds;

                        if (ground.Id != groundToRemove.Id)
                        {
                            collection.Insert(t);
                        }
                        break;
                    case "Member":
                        Member member = t as Member;
                        Member memberToRemove = item as Member;
                        if (member.MemberId != memberToRemove.MemberId)
                        {
                            collection.Insert(t);
                        }
                        break;
                    case "MemberLogin":
                        MemberLogin l = t as MemberLogin;
                        MemberLogin memberLoginToRemove = item as MemberLogin;
                        if (l.LoginIdentifier != memberLoginToRemove.LoginIdentifier)
                        {
                            collection.Insert(t);
                        }
                        break;

                }
            }



        }

        public void DeleteLoginTest()
        {
          
            collection.DeleteAll();
        }
        public T GetItemFromDatabase(int memberId)
        {
            //var foundMember = collection.Find(Query.EQ("MemberId", memberId));
          var foundMember =  collection.FindById(memberId);
            return foundMember;
        }

        public int FindMaxId()
        {
            int maxId;
            if (collection.Count() == 0)
            {
                maxId = 0;
            }
            else {
                PropertyInfo idProperty = null;

                switch (typeof(T).Name)
                {
                    case "Member":

                 idProperty = typeof(T).GetProperty("MemberId");

                        break;

                    case "FishingGrounds":
                        idProperty = typeof(T).GetProperty("Id");

                        break;
                    default:


                        break;
                        
                }

                if (idProperty == null)
                {
                    return 0;
                }

                maxId = collection.FindAll().Max(x => (int)idProperty.GetValue(x));

            }

               return maxId;
            
        }



        public bool IsInDatabase(T item)
        {

            var login = item as Models.MemberLogin;
            return collection.Exists(Query.And(Query.EQ("LoginIdentifier", login.LoginIdentifier), Query.EQ("Password", login.Password)));


        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db?.Dispose();
            }
        }

    }
}
