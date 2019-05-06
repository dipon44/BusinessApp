


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallBusinessManagementApp.Models.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
        [NotMapped]
        public  List<Category> Categories { get; set; }

   
       
    }
}