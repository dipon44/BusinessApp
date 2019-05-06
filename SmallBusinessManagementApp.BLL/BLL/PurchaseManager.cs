using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmallBusinessManagementApp.Models.Models.Purchase;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL.BLL
{
   public class PurchaseManager
   {
       private PurchaseRepository _purchaseRepository = new PurchaseRepository();

       public bool Add(Purchase purchase)
       {
           return _purchaseRepository.Add(purchase);
       }

       public List<SelectListItem> GetSupplierSelectListItems()
       {
           return _purchaseRepository.GetSupplierSelectListItems();
       }

       public List<SelectListItem> GetProductSelectListItems()
       {
           return _purchaseRepository.GetProductSelectListItems();
       }
    }
}
