using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessManagementApp.Models.Models.Sales
{
    public class SalesDetails
    {
        public int  Id { get; set; }
        public int  Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sales Sales { get; set; }
    }
}
