using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.BLL.BLL;

namespace SmallBusinessManagementApp.Controllers
{
    public class ProductsController : Controller
    {
        public Product product;
        ProductManager _productManager = new ProductManager();
       
        public ActionResult Add()
        {
            product = new Product();
            product.CategoryLookUp = _productManager.GetCategorySelectListItems();
            
         
            return View(product);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product product)
        {
            try
            {

                if (ModelState.IsValid )
                {
                   
                    if (product.UploadFiles != null && product.UploadFiles[0] != null)
                    {
                        var productFiles = new List<ProductFiles>();
                        foreach (var uploadFile in product.UploadFiles)
                        {
                            var productFile = new ProductFiles();
                            var fileByte = new byte[uploadFile.ContentLength];
                            uploadFile.InputStream.Read(fileByte, 0, uploadFile.ContentLength);
                            productFile.File = fileByte;
                            productFile.FileName = uploadFile.FileName;

                            productFiles.Add(productFile);
                        }

                        product.ProductFiles = productFiles;
                    }

                   
                        var isAdded = _productManager.Add(product);
                        product.CategoryLookUp = _productManager.GetCategorySelectListItems();
                        if (isAdded)
                        {
                            ViewBag.SMsg = "Save Successfully";
                        }

                        else
                        {
                            ViewBag.FMsg = "Save Failed";
                        }
                    }

                   
            

            }
            catch (Exception e)
            {

                ViewBag.FMsg = e.Message;
            }

            return View(product);

        }

        public ActionResult Show()
        {

            var dataList = _productManager.GetAll();
            return View(dataList);
        }

        public bool GetDuplicateProduct(string code)
        {
            return _productManager.GetDuplicateProduct(code);
        }

        public ActionResult Edit(int id)
        {
            var product = _productManager.GetProductById(id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = _productManager.Update(product);

                    if (isUpdated)
                    {
                        return RedirectToAction("Show");
                    }
                    ViewBag.FMsg = "Failed!!!!";
                }
                return View(product);
            }
            catch (Exception e)
            {
                ViewBag.EMsg = e.Message;
                return View(product);

            }
        }

        public ActionResult Delete(int id, int idFile)
        {
            bool isDeleted = false;
            Product product = _productManager.GetProductById(id);
            ProductFiles productFiles = _productManager.GetProductFilesById(idFile);
            if (product != null)
            {
                isDeleted = _productManager.Delete(product, productFiles);
            }
            if (isDeleted)
            {
                ViewBag.DMsg = "Deleted";
            }
            else
            {
                ViewBag.FMsg = "not deleted";
            }

            return RedirectToAction("Create");

        }

        
    }
}