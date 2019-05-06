using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmallBusinessManagementApp.Models.Models.Purchase
{
   public class PurchaseDetails
    {
       public int Id { get; set; }
    
       public string Code { get; set; }
       public string ManufacturedDate { get; set; }
       public string ExpiredDate { get; set; }
       public int PurchaseQuantity  { get; set; }
       public int UnitPrice { get; set; }
       public int TotalPrice { get; set; }
       public int PreviousMRP { get; set; }
       public int PurchaseId { get; set; }
       
       public int NewMRP { get; set; }
       public int ProductId { get; set; }
       public virtual Product Product { get; set; }
       public virtual Purchase Purchase { get; set; }

       

       
    }
}
