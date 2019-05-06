using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.BLL.BLL;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Models.ViewModels;

namespace SmallBusinessManagementApp.Controllers
{
    public class SuppliersController : Controller
    {
        private SupplierManager _manager = new SupplierManager();

        public ActionResult Add()
        {
            SupplierViewModel viewModel = new SupplierViewModel();


            viewModel.Suppliers = _manager.GetAll();

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {

            var viewModel = new SupplierViewModel
            {
                Suppliers = _manager.GetAll(),
                Supplier = supplier
            };

            if (ModelState.IsValid)
            {
                bool isSaved = _manager.Saved(supplier);
                if (isSaved)
                {
                    ViewBag.SMsg = "Saved Success";
                }
                else
                {
                    ViewBag.FMsg = "Code already Exist!";
                }
            }

            return View(viewModel);
           
        }
        public ActionResult Edit(int id)
        {
            var supplier = _manager.GetSupplierById(id);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = _manager.Update(supplier);

                    if (isUpdated)
                    {
                        return RedirectToAction("Save");
                    }
                    ViewBag.FMsg = "Failed!!!!";
                }
                return View(supplier);
            }
            catch (Exception e)
            {
                ViewBag.EMsg = e.Message;
                return View(supplier);

            }
        }

        public ActionResult Delete(int id)
        {
            bool isDeleted = false;
            Supplier supplier = _manager.GetSupplierById(id);
            if (supplier != null)
            {
                isDeleted = _manager.Delete(supplier);
            }
            if (isDeleted)
            {
                TempData["SMsg"] = "Deleted Successfully";

            }
            TempData["FMsg"] = "Not Deleted";
            return RedirectToAction("Save");
        }
	}
}