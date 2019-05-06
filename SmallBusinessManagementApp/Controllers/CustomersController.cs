using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.BLL;
using SmallBusinessManagementApp.BLL.BLL;
using SmallBusinessManagementApp.Models.Models;

namespace SmallBusinessManagementApp.Controllers
{
    public class CustomersController : Controller
    {

        CustomerManager _customerManager = new CustomerManager();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (customer.UploadFiles != null && customer.UploadFiles[0] != null)
                    {
                        var customerFiles = new List<CustomerFiles>();
                        foreach (var uploadFile in customer.UploadFiles)
                        {
                            var customerFile = new CustomerFiles();
                            var fileByte = new byte[uploadFile.ContentLength];
                            uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                            customerFile.File = fileByte;
                            customerFile.FileName = uploadFile.FileName;

                            customerFiles.Add(customerFile);
                        }

                        customer.CustomerFiles = customerFiles;
                    }

                    if (GetDuplicateCustomer(customer.Code) == false)
                    {
                        var isAdded = _customerManager.Add(customer);
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
                        ViewBag.DMsg = "Customer with this Code already exists";
                    }

                }

            }
            catch (Exception e)
            {

                ViewBag.FMsg = e.Message;
            }

            return View();
        }
        public ActionResult Show()
        {

            var dataList = _customerManager.Show();
            return View(dataList);
        }


        public ActionResult Edit(int id)
        {
            var customer = _customerManager.GetCustomerById(id);
            return View(customer);
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = _customerManager.Update(customer);

                    if (isUpdated)
                    {
                        return RedirectToAction("Show");
                    }
                    ViewBag.FMsg = "Failed!!!!";
                }
                return View(customer);
            }
            catch (Exception e)
            {
                ViewBag.EMsg = e.Message;
                return View(customer);

            }
        }

        public ActionResult Delete(int id, int idFile)
        {
            bool isDeleted = false;
            Customer customer = _customerManager.GetCustomerById(id);
            CustomerFiles customerFiles = _customerManager.GetCustomerFilesById(idFile);
            if (customer != null)
            {
                isDeleted = _customerManager.Delete(customer, customerFiles);
            }
            if (isDeleted)
            {
                TempData["SMsg"] = "Deleted Successfully";

            }
            TempData["FMsg"] = "Not Deleted";
            return RedirectToAction("Show");
        }




        public bool GetDuplicateCustomer(string code)
        {
            return _customerManager.GetDuplicateCustomer(code);
        }

	}
}