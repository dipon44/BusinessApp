using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmallBusinessManagementApp.DatabaseContext.DatabaseContext;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Models.Models.Purchase;

namespace SmallBusinessManagementApp.Repository.Repository
{
    public class PurchaseRepository
    {
        private SmallBusinessDbContext db = new SmallBusinessDbContext();

        public bool Add(Purchase purchase)
        {
            bool isSaved = false;

            db.Purchases.Add(purchase);
            int saved = db.SaveChanges();

            if (saved > 0)
            {
                isSaved = true;
            }
            
            
            return isSaved;
        }

        public List<SelectListItem> GetSupplierSelectListItems()
        {
            var dataList = db.Suppliers.ToList();

            var SupplierSelectListItems = new List<SelectListItem>();

            SupplierSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var supplier in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = supplier.Name;
                    selectListItem.Value = supplier.Id.ToString();

                    SupplierSelectListItems.Add(selectListItem);
                }
            }
            return SupplierSelectListItems;
        }

        public List<SelectListItem> GetProductSelectListItems()
        {
            List<Product> dataList = db.Products.ToList();

            var ProductSelectListItems = new List<SelectListItem>();

            ProductSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var product in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = product.Name;
                    selectListItem.Value = product.Id.ToString();

                    ProductSelectListItems.Add(selectListItem);
                }
            }
            return ProductSelectListItems;
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

    }
}
