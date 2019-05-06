using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public List<SelectListItem> GetCategorySelectListItems()
        {
            return _productRepository.GetCategorySelectListItems();
        }

        public bool GetDuplicateProduct(string code)
        {
            return _productRepository.GetDuplicateProduct(code);
        }

        public bool Update(Product product)
        {
            bool isUpdated = _productRepository.Update(product);
            return isUpdated;
        }

        public Product GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);
            return product;
        }

        public bool Delete(Product product, ProductFiles productFiles)
        {
            bool isDeleted = _productRepository.Delete(product, productFiles);
            return isDeleted;
        }

        public ProductFiles GetProductFilesById(int id)
        {
            ProductFiles productFiles = _productRepository.GetProductFilesById(id);
            return productFiles;
        }
    }

    
}
