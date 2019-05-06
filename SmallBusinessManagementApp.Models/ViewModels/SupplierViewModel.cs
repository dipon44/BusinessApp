using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusinessManagementApp.Models.Models;

namespace SmallBusinessManagementApp.Models.ViewModels
{
    public class SupplierViewModel
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
        public Supplier Supplier { get; set; }
    }
}
