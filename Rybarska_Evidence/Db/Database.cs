using LiteDB;
using Rybarska_Evidence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Db
{
  public class Database
    {

        private readonly LiteDatabase db;

        public Database()
        {
            db = new LiteDatabase(@"MyData.db");
        }

        public LiteDatabase GetDatabaseInstance()
        {
            return db;
        }


    }
}
