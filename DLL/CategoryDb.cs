using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;

       public CategoryDb()
       {
           db = new LinkHubDbEntities();
       }
       public IEnumerable<tbl_Category> GetALL()
       {
           return db.tbl_Category.ToList();
       }
       public tbl_Category GetByID(int Id)
       {
           return db.tbl_Category.Find(Id);
       }
       public void Insert(tbl_Category category)
       {
           db.tbl_Category.Add(category);
           Save();
       }
       public void Delete(int Id)
       {
           tbl_Category category=db.tbl_Category.Find(Id);
           db.tbl_Category.Remove(category);
           Save();
       }
       public void Update(tbl_Category category)
       {
           db.Entry(category).State = EntityState.Modified;
       }
       public void Save()
       {
           db.SaveChanges();
       }
    }
}
