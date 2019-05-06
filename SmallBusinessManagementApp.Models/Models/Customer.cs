using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallBusinessManagementApp.Models.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public int LoyalityPoint { get; set; }
       
        public virtual List<CustomerFiles> CustomerFiles { get; set; }

       
        [NotMapped]
        public List<HttpPostedFileBase> UploadFiles { get; set; }
    }
}
