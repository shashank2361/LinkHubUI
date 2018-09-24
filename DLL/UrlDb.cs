using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class UrlDb
    {
        private LinkHubDbEntities db;
        public UrlDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetALL() {
            return db.tbl_Url.ToList();
        }
        public tbl_Url GetByID(int Id)
        {
            return db.tbl_Url.Find(Id);

        }


        public void Insert(tbl_Url url) {
            db.tbl_Url.Add(url);
        }
        public void Delete(int id) {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public void Update(tbl_Url url) {
            db.Entry(url).State = EntityState.Modified;
        }
        //void Save();


    }
}
