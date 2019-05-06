using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessManagementApp.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public string CategoryName { get; set; }
        public virtual Category Category { get; set; }
        
        public int ReorderLevel { get; set; }
       
        public string Description { get; set; }

        [NotMapped]
        public List<SelectListItem> CategoryLookUp { get; set; }

        
        [NotMapped]
        public List<Product> Products { get; set; }

        public virtual List<ProductFiles> ProductFiles { get; set; }


        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
