using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Models.Models;
using SmallBusinessManagementApp.Repository;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public List<Customer> Show()
        {
            var dataList = _customerRepository.Show();
            return dataList;
        }

        public bool Update(Customer customer)
        {
            bool isUpdated = _customerRepository.Update(customer);
            return isUpdated;
        }

        public bool Delete(Customer customer, CustomerFiles customerFiles)
        {
            bool isDeleted = _customerRepository.Delete(customer,customerFiles);
            return isDeleted;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            return customer;
        }

        public CustomerFiles GetCustomerFilesById(int id)
        {
            CustomerFiles customerFiles = _customerRepository.GetCustomerFilesById(id);
            return customerFiles;
        }

        public bool GetDuplicateCustomer(string code)
        {
            return _customerRepository.GetDuplicateCustomer(code);
        }
    }
}
