using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallBusinessManagementApp.DatabaseContext;
using SmallBusinessManagementApp.DatabaseContext.DatabaseContext;
using SmallBusinessManagementApp.Models;
using SmallBusinessManagementApp.Models.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SmallBusinessManagementApp.Repository.Repository
{
    public class CategoryRepository
    {
        private SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Category category)
        {
            bool isSaved = false;

            db.Categories.Add(category);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }

            return isSaved;
        }


        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Delete(Category category)
        {
            db.Categories.Remove(category);
            int deleted = db.SaveChanges();
            if (deleted>0)
            {
                return true;
            }
            return false;
        }

        public Category GetCustomerById(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.Id==id);
            

            return category;
        }


        public bool Update(Category category)
        {
            bool isUpdated = false;
            db.Entry(category).State = EntityState.Modified;
            int isChanged = db.SaveChanges();
            if (isChanged > 0)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool GetDuplicateCustomer(string code)
        {
            Category category = db.Categories.Where(c => c.Code == code).FirstOrDefault();
            if (category != null)
            {
                return true;
            }
            return false;
        }

       

    }
}