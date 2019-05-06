using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmallBusinessManagementApp.DatabaseContext.DatabaseContext;
using SmallBusinessManagementApp.Models.Models;

namespace SmallBusinessManagementApp.Repository.Repository
{
    public class ProductRepository
    {
        private SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Product product)
        {
            bool isSaved = false;

            db.Products.Add(product);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }

            return isSaved;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public List<SelectListItem> GetCategorySelectListItems()
        {
            var dataList = db.Categories.ToList();

            var districtSelectListItems = new List<SelectListItem>();

            districtSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var category in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = category.Name;
                    selectListItem.Value = category.Name;

                    districtSelectListItems.Add(selectListItem);
                }
            }
            return districtSelectListItems;
        }

        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }

        public bool GetDuplicateProduct(string code)
        {
            Product product = db.Products.Where(c => c.Code == code).FirstOrDefault();
            if (product != null)
            {
                return true;
            }
            return false;
        }

        public bool Update(Product product)
        {
            bool isUpdated = false;
            db.Entry(product).State = EntityState.Modified;
            int isChanged = db.SaveChanges();
            if (isChanged > 0)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public Product GetProductById(int id)
        {
            Product product = db.Products.Where(c => c.Id == id).FirstOrDefault();
            return product;
        }

        public bool Delete(Product product, ProductFiles productFiles)
        {
            
            db.Products.Remove(product);
            int isChanged = db.SaveChanges();
            db.ProductFiles.Remove(productFiles);
            int isChangedFiles = db.SaveChanges();
            if (isChanged > 0 && isChangedFiles>0)
            {
                return true;
            }
            return false;
        }

        public ProductFiles GetProductFilesById(int id)
        {
            ProductFiles productFiles = db.ProductFiles.Where(c => c.Id == id).FirstOrDefault();
            return productFiles;
        }
    }
}
