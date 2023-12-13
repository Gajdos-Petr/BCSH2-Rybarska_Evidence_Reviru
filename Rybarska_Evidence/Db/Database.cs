using LiteDB;
using Rybarska_Evidence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybarska_Evidence.Db
{
  public  class Database
    {
        private readonly LiteDatabase db;

        public Database()
        {
            string dbPath = "myDatabase.db";
            db = new LiteDatabase(dbPath);
        }

        public LiteCollection<Member> People => (LiteCollection<Member>)db.GetCollection<Member>("member");
    }
}
