using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.DatabaseContext.DatabaseContext;
using SmallBusinessManagementApp.Models.Models;

namespace SmallBusinessManagementApp.Repository.Repository
{
    public class SupplierRepository
    {
        private SmallBusinessDbContext db = new SmallBusinessDbContext();


        public bool Saved(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            int isSaved = db.SaveChanges();
            if (isSaved > 0)
            {
                return true;
            }
            return false;
        }

        public bool Exist(Supplier supplier)
        {
            Supplier exist = db.Suppliers.Where(c => c.Code == supplier.Code).FirstOrDefault();
            if (exist == null)
            {
                return false;
            }
            return true;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool Update(Supplier supplier)
        {
            bool isUpdated = false;
            db.Entry(supplier).State = EntityState.Modified;
            int isChanged = db.SaveChanges();
            if (isChanged > 0)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool Delete(Supplier supplier)
        {
            bool isDeleted = false;
            db.Suppliers.Remove(supplier);
            int isChanged = db.SaveChanges();
            if (isChanged > 0)
            {
                isDeleted = true;
            }
            return isDeleted;
        }



        public Supplier GetsupplierById(int id)
        {
            Supplier supplier = db.Suppliers.Where(c => c.Id == id).FirstOrDefault();
            return supplier;
        }
    }
}
