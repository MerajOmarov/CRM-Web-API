using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.CommandModels
{
    public class _product_Model_write
    {
        [Key]
        public int _product_ID { get; set; }
        public string _product_Name { get; set; }
        public string _product_Description { get; set; }
        public string _product_Videocard { get; set; }
        public string _product_OperatingSystem { get; set; }
        public string _product_Screen { get; set; }
        public string _product_Prosessor { get; set; }
        public double _product_Price { get; set; }
        public string _product_Company { get; set; }
        public Guid _product_Barcode { get; set; }
        public DateTime _product_CreatedTime { get; set; }
        
        //Navigation parametr
        public IEnumerable<_order_Model_write> _orders_Of_product_ { get; set; }
    }
}
