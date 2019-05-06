using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBusinessManagementApp.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an unique code")]
        public string Code { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter an Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your contact")]
        public string Contact { get; set; }


        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }
    }
}
