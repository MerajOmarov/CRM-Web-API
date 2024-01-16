using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.QueryModel
{
    public class _product_Model_read
    {
        [Key]
        public int _product_ID { get; set; }
        public string _product_Name { get; set; }
        public string _product_Description { get; set; }
        public Guid _product_Barcode { get; set; }
        public string _product_Videocard { get; set; }
        public string _product_OperatingSystem { get; set; }
        public string _product_Screen { get; set; }
        public string _product_Prosessor { get; set; }
        public string _product_Company { get; set; }
        public double _product_Price { get; set; }
       
    }
}
