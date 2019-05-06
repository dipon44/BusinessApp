using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmallBusinessManagementApp.Models;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Repository;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public bool Delete(Category category)
        {
            bool isDeleted = _categoryRepository.Delete(category);
            return isDeleted;
        }

        public Category GetCategoryById(int id )
        {
            return _categoryRepository.GetCustomerById(id);
        }

        public bool Update(Category category)
        {
            bool isUpdated = _categoryRepository.Update(category);
            return isUpdated;
        }

        public bool GetDuplicateCustomer(string code)
        {
            return _categoryRepository.GetDuplicateCustomer(code);
        }
    }
}