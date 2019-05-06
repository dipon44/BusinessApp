using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmallBusinessManagementApp.Models.Models.Sales
{
    public class Sales
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int LoyalityPoint { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<SalesDetails> SalesDetailses { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> CustomerLookUp { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> ProductLookUp { get; set; }

        [NotMapped]
        public int ProductId { get; set; }

        [NotMapped]
        public virtual Product Product { get; set; }
        [NotMapped]
        public virtual SalesDetails SalesDetails{ get; set; }


    }
}
