using LiteDB;
using Rybarska_Evidence.Model;
using System;
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
           
                collection.Insert(item);
            
        }

        public void UpdateItemInDatabase(T item)
        {
            using (db)
            {
                collection.Update(item);
            }
        }

        public void DeleteItemInDatabase(T item)
        {
            
                Member memberSa = item as Member;
                collection.Delete(memberSa.MemberId);
                //Type foudnedType = typeof(T);
                //switch (foudnedType.Name)
                //{
                //    case "Member":

                //        break;
                //}

        }


        public int FindMaxId()
        {
        
                PropertyInfo idProperty = typeof(T).GetProperty("MemberId");

                if (idProperty == null)
                {
                    // Nějaký kód pro chybové zprávy, protože MemberId není ve vašem typu T.
                    return 0;
                }

                var maxId = collection.FindAll().Max(x => (int)idProperty.GetValue(x));
               return maxId;
            
        }



        public bool IsInDatabase(T item)
        {
            using (db)
            {
                var idProperty = typeof(T).GetProperty("LoginIdentifier"); 
                if (idProperty == null)
                {
                    throw new ArgumentException("Třída musí mít vlastnost 'Id'.");
                }

                var itemId = idProperty.GetValue(item, null);

                if (itemId == null)
                {
                    return false;
                }

                return true;
            }
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
