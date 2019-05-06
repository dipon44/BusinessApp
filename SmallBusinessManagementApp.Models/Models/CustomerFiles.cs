using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SmallBusinessManagementApp.Models.Models
{
    public class CustomerFiles
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }

        public Customer Customer { get; set; }

       
    }
}
