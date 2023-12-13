using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Db
{
    public class DatabaseManager<T>
    {
        private readonly LiteDatabase db;
        private readonly ILiteCollection<T> collection;


        public DatabaseManager(LiteDatabase database, string collectionName)
        {
            db = database;
            collection = db.GetCollection<T>(collectionName);
        }


        public ObservableCollection<T> GetAll()
        {
            return new ObservableCollection<T>(collection.FindAll());
        }


        public void Add(T item)
        {
            collection.Insert(item);
        }

   
    }
}
