using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using SmallBusinessManagementApp.DatabaseContext.DatabaseContext;
using SmallBusinessManagementApp.Models;
using SmallBusinessManagementApp.Models.Models;
using ModelState = System.Web.WebPages.Html.ModelState;

namespace SmallBusinessManagementApp.Repository.Repository
{
    public class CustomerRepository
    {
        private SmallBusinessDbContext db = new SmallBusinessDbContext();
  
        public bool Add(Customer customer)
        {
            bool isSaved = false;

            db.Customers.Add(customer);
            int saved = db.SaveChanges();
            if (saved > 0)
            {
                isSaved = true;
            }

            return isSaved;
        }


        public List<Customer> Show()
        {
            var dataList = db.Customers.ToList();
            return dataList;
        }

        public bool Update(Customer customer)
        {
            bool isUpdated = false;
            db.Entry(customer).State = EntityState.Modified;
            int isChanged = db.SaveChanges();
            if (isChanged > 0)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool Delete(Customer customer, CustomerFiles customerFiles)
        {
            db.Customers.Remove(customer);
            int isChanged = db.SaveChanges();
            db.CustomerFiles.Remove(customerFiles);
            int isChangedFile = db.SaveChanges();
            if (isChanged > 0 && isChangedFile>0)
            {
                return true;
            }
            return false;
        }



        public Customer GetCustomerById(int id)
        {
            Customer customer = db.Customers.Where(c => c.Id == id).FirstOrDefault();
            return customer;
        }

        public CustomerFiles GetCustomerFilesById(int id)
        {
            CustomerFiles customerFiles = db.CustomerFiles.Where(c => c.Id == id).FirstOrDefault();
            return customerFiles;
        }

        public bool GetDuplicateCustomer(string code)
        {
            Customer customer = db.Customers.Where(c => c.Code == code).FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
        }
    }


}
    


        
    

        

    
    
    


