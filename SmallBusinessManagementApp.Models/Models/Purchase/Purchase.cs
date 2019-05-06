using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmallBusinessManagementApp.Models.Models.Purchase
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Date { get; set; }

        public int  BillNo { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

             

        public virtual List<PurchaseDetails> PurchaseDetailses { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> SupplierLookUp { get; set; }

        [NotMapped]
        public int ProductId { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> ProductLookUp { get; set; }

        [NotMapped]
        public virtual PurchaseDetails PurchaseDetails { get; set; }

      

        

    }
}
