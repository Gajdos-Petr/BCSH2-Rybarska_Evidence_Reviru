using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
          //  string databasePath = Path.Combine("Data", "FishingData.db");

         //   db = new LiteDatabase(databasePath));
            collection = db.GetCollection<T>(collectionName);
        }
  

        public ObservableCollection<T> LoadData()
        {
            using (db)
            {
                return new ObservableCollection<T>(collection.FindAll());
            }
        }

        public void AddNewItemToDatabase(T item)
        {
            using(db)
            {
                collection.Insert(item);
            }
        }

        



        //public bool IsInDatabase(T item)
        //{
        //    var idProperty = typeof(T).GetProperty("Id"); // Nastavte název vlastnosti identifikátoru
        //    if (idProperty == null)
        //    {
        //        throw new ArgumentException("Třída musí mít vlastnost 'Id'.");
        //    }

        //    var itemId = idProperty.GetValue(item, null);

        //    if (itemId == null)
        //    {
        //        return false; // Pokud Id je null, nemůže být v databázi
        //    }

        //    return true;
        //}

        //public void Add(T item)
        //{
        //    collection.Insert(item);
        //}

   
    }
}
