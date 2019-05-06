using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SmallBusinessManagementApp.Models.Models.Sales;
using SmallBusinessManagementApp.Repository.Repository;

namespace SmallBusinessManagementApp.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool Add(Sales sales)
       {
           return _salesRepository.Add(sales);
       }

       public List<SelectListItem> GetCustomerSelectListItems()
       {
           return _salesRepository.GetCustomerSelectListItems();
       }

       public List<SelectListItem> GetProductSelectListItems()
       {
           return _salesRepository.GetProductSelectListItems();
       }
    }
}
