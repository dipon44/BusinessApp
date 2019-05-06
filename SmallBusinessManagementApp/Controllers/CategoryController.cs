using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.BLL;
using SmallBusinessManagementApp.Models;
using SmallBusinessManagementApp.Models.Models;


namespace SmallBusinessManagementApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
      
        [HttpGet]
        public ActionResult Add()
        {
            var datalist=_categoryManager.GetAll();
            return View(datalist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            try
            {

                if (ModelState.IsValid && model.Name!=null && model.Code!=null)
                {
                    if (GetDuplicateCustomer(model.Code) == false)
                    {

                        var isAdded = _categoryManager.Add(model);

                        if (isAdded)
                        {
                            ViewBag.SMsg = "Save Successfully";
                        }

                       

                        else
                        {
                            ViewBag.FMsg = "Save Failed";
                        }
                    }

                    else
                    {
                        ViewBag.DMsg = "Customer with this Code already exixts";
                    }
                }

                else
                {
                    ViewBag.NMsg = "This field is required";
                }


                return View(_categoryManager.GetAll());
              

            }
            catch (Exception e)
            {

                ViewBag.FMsg = e.Message;
            }

            
            return View(_categoryManager.GetAll());

        }

        public ActionResult Delete(int id )
        {
            bool isDeleted = false;
           Category  category = _categoryManager.GetCategoryById(id);
            if (category != null)
            {
                isDeleted = _categoryManager.Delete(category);
            }
            if (isDeleted)
            {
                ViewBag.DMsg = "Deleted";
            }
            else
            {
                ViewBag.FMsg = "not deleted";
            }
           
            return RedirectToAction("Add");

        }

        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = _categoryManager.Update(category);

                    if (isUpdated)
                    {
                        return RedirectToAction("Add");
                    }
                    ViewBag.FMsg = "Failed!!!!";
                }
                return View(category);
            }
            catch (Exception e)
            {
                ViewBag.EMsg = e.Message;
                return View(category);

            }
        }

        public bool GetDuplicateCustomer(string code)
        {
            return _categoryManager.GetDuplicateCustomer(code);
        }

   
    }
}