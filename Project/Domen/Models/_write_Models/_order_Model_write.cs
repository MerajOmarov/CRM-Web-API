using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.CommandModels
{
    public class _order_Model_write
    {
        [Key]
        public int _order_ID { get; set; }
        public Guid _order_Code { get; set; }
        public Guid _order_customer_PIN { get; set; }
        public Guid _order_product_Barcode { get; set; }
        public DateTime _order_Deedline { get; set; }
        public DateTime _order_CreatedTime { get; set; }

        // Navigation parametrs
        public int _customer_ID { get; set; }
        public _customer_Model_write _order_Customer { get; set; }
        public int _product_ID { get; set; }
        public _product_Model_write _order_Product { get; set; }
    }
}
