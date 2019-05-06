using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.Models.Models.Sales;
using SmallBusinessManagementApp.BLL.BLL;

namespace SmallBusinessManagementApp.Controllers
{
    public class SalesController : Controller
    {
        SalesManager _salesManager = new SalesManager();
        public ActionResult Add()
        {
            Sales sales = new Sales();
            sales.CustomerLookUp = _salesManager.GetCustomerSelectListItems();
            sales.ProductLookUp = _salesManager.GetProductSelectListItems();
            return View(sales);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Sales sales)
        {
            sales.CustomerLookUp = _salesManager.GetCustomerSelectListItems();
            sales.ProductLookUp = _salesManager.GetProductSelectListItems();

            if (sales.SalesDetailses != null && sales.SalesDetailses.Count > 0)
            {


                var isAdded = _salesManager.Add(sales);
                if (isAdded)
                {
                    ViewBag.SMsg = "Sales Success";
                    return View(sales);
                }
            }
            ViewBag.FMsg = "sales Failed";
            return View(sales);
        }
	}
}