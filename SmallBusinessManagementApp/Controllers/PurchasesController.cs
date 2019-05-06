using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.BLL.BLL;
using SmallBusinessManagementApp.Models.Models.Purchase;
using SmallBusinessManagementApp.Models.ViewModels;

namespace SmallBusinessManagementApp.Controllers
{
    public class PurchasesController : Controller
    {
       
        
        PurchaseManager _purchaseManager = new PurchaseManager();

        public ActionResult Add()
        {
            Purchase purchase = new Purchase();
            purchase.SupplierLookUp = _purchaseManager.GetSupplierSelectListItems();
            purchase.ProductLookUp = _purchaseManager.GetProductSelectListItems();

            return View(purchase);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Purchase purchase)
        {
            purchase.SupplierLookUp = _purchaseManager.GetSupplierSelectListItems();
            purchase.ProductLookUp = _purchaseManager.GetProductSelectListItems();

            if (purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {


                var isAdded = _purchaseManager.Add(purchase);
                if (isAdded)
                {
                    ViewBag.SMsg = "Purchase Success";
                    return View(purchase);
                }
            }
            ViewBag.FMsg = "Purchase Failed";
            return View(purchase);
        }
	}
}