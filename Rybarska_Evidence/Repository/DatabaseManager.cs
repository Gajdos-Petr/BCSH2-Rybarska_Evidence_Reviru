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

        public DatabaseManager()
        {
            string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            db = new LiteDatabase(Path.GetFullPath(Path.Combine(_BaseDirectory, @"..\..\..\..\Db\FishingData.db")));
        }

        public ObservableCollection<T> LoadData()
        {
          
                return new ObservableCollection<T>(collection.FindAll());
        }


        public ObservableCollection<Catch> LoadCatches(int memberId)
        {


            List<Catch> allCatches = LoadData().ToList().Cast<Catch>().ToList();
            // Použijeme Where metodu na kolekci pro filtraci
            var filteredCatches = new ObservableCollection<Catch>(allCatches.FindAll(c => c.MemberId == memberId));

            // Vrátíme filtrovanou kolekci
            return filteredCatches;
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
                    string password = GeneratePassword();
                    var newLogin = new Models.MemberLogin { LoginIdentifier = memberSa.MemberId, Password = password };
                    collectionLogins.Insert(newLogin);
                    MessageBox.Show($"Byl přidán nový člen {memberSa.FirstName}  {memberSa.LastName} \nID: {memberSa.MemberId}\nHeslo: {password}");
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

                    case "Catch":
                        Catch c = t as Catch;
                        Catch catchToRemove = item as Catch;
                        if (c.Id != catchToRemove.Id)
                        {
                            collection.Insert(t);
                        }
                        break;

                }
            }



        }


        public List<int> LoadGroundNumbers(Func<T, int> nameSelector)
        {
            var names = collection.FindAll().Select(nameSelector).ToList();
            return names;
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

                    case "Catch":
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

        private string GeneratePassword()
        {
            int length = 12;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }





      public  int GetMostFrequentGroundNumber()
        {

            var conn = db.GetCollection<Catch>("catches");
            List<Catch> catches = conn.FindAll().ToList();
            
            // Použití LINQ pro získání nejčastěji se vyskytujícího revíru.
            var mostFrequentGroundNumber = catches
                .GroupBy(c => c.GroundNumber)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();

            return mostFrequentGroundNumber;
        }



        public StatsMember GetMemberStats(int memberId)
        {
            StatsMember stats = new StatsMember();
            var conn = db.GetCollection<Catch>("catches");
            List<Catch> memberCatches= conn.Find(c => c.MemberId == memberId).ToList();
            stats.CountOfVisits = memberCatches.Count();


            var fishGroups = memberCatches
                .SelectMany(c => new[] { c.FishOne, c.FishTwo }) // Sloučení všech ryb do jednoho seznamu
                .Where(fish => fish.FishName != "-")                      // Odstranění potenciálních null hodnot
                .GroupBy(fish => fish.FishName)                   // Seskupení podle názvu ryby
                .OrderByDescending(group => group.Count());       // Seřazení podle počtu ulovených ryb sestupně

            var mostCaughtFishGroup = fishGroups.FirstOrDefault();

            string mostCaughtFishName = mostCaughtFishGroup?.Key;
            if (string.IsNullOrEmpty(mostCaughtFishName)) 
            {
                stats.MostCaughtFishName = "Zadna";
            }
            else
            {
            stats.MostCaughtFishName = mostCaughtFishName;

            }
            if (memberCatches.Any())
            {
                int mostFrequentGroundNumber = memberCatches          
    .GroupBy(c => c.GroundNumber)
    .OrderByDescending(group => group.Count())
    .Select(group => group.Key)
    .First();
                stats.MostFrequentGroundNumber = mostFrequentGroundNumber;

            }
            else
            {
                stats.MostFrequentGroundNumber = 0;
            }
            //TopThreeCatch(memberId);
            return stats;
        }

        //public void TopThreeCatch(int memberId)
        //{
        //    var conn = db.GetCollection<Catch>("catches");
        //    List<Catch> memberCatches = conn.Find(c => c.MemberId == memberId).ToList();
        //    int numberForSort = 0;

        //    if (memberCatches.Any())
        //    {
        //        if (memberCatches.Count > 3)
        //        {
        //            numberForSort = 3;
        //        }
        //        else
        //        {
        //            numberForSort = memberCatches.Count;
        //        }
        //        var top3GroundNumbers = memberCatches
        //            .GroupBy(c => c.GroundNumber)
        //            .OrderByDescending(group => group.Count())
        //            .Take(numberForSort)
        //            .Select(group => group.Key)
        //            .ToList();


        //        foreach (var groundNumber in top3GroundNumbers)
        //        {
        //            //Console.WriteLine($"GroundNumber: {groundNumber}");
        //            //MessageBox.Show(groundNumber.ToString());
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Člen nemá žádné úlovky.");
        //    }

        //}
        public List<Carry> GetTopThreeCatches(int memberId)
        {
            var conn = db.GetCollection<Catch>("catches");
            List<Catch> memberCatches = conn.Find(c => c.MemberId == memberId).ToList();
            int numberToGet = 0;

            if (memberCatches.Count < 3)
            {
                numberToGet = memberCatches.Count;
            }
            else
            {
                numberToGet = 3;
            }
            

            if (memberCatches.Any())
            {
                // Sjednocení úlovků FishOne a FishTwo do jednoho seznamu
                var allCatches = memberCatches.SelectMany(c => new[] { c.FishOne, c.FishTwo })
                                               .Where(fish => fish != null)
                                               .ToList();

                // Seřazení úlovků podle váhy sestupně a výběr prvních tří
                var topThreeCatches = allCatches.OrderByDescending(c => c.Weight)
                                               .Take(numberToGet)
                                               .ToList();

                return topThreeCatches;
            }
            else
            {
                MessageBox.Show("Člen nemá žádné úlovky.");
                return new List<Carry>();
            }
        }



        public ObservableCollection<Models.Stats> GetStatsForGrounds()
        {
            ObservableCollection<Models.Stats> statsCollection = new ObservableCollection<Models.Stats>();

            var conn = db.GetCollection<Catch>("catches");
            List<Catch> catchesToSort = conn.FindAll().ToList();

            var groundsGrouped = catchesToSort
                .GroupBy(c => c.GroundNumber)
                .ToList();

            foreach (var group in groundsGrouped)
            {
                int groundNumber = group.Key;

                Models.Stats stats = new Models.Stats
                {
                    Ground = groundNumber.ToString(), // Změňte podle struktury vaší databáze
                    TotalWeight = group.Sum(c => (c.FishOne?.Weight ?? 0) + (c.FishTwo?.Weight ?? 0)),
                    FishCount = group.Sum(c => (c.FishOne != null ? 1 : 0) + (c.FishTwo != null ? 1 : 0)).ToString(),
                    TotalSize = group.Sum(c => (c.FishOne?.Lenght ?? 0) + (c.FishTwo?.Lenght ?? 0))
                };

                // Přidejte statistiky do kolekce
                statsCollection.Add(stats);
            }

            return statsCollection;
        }

    }


}

