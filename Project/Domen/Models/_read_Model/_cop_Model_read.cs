using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.QueryModel
{
    public class _cop_Model_read
    {
        [Key]
        public int _cop_ID { get; set; }

        //Order
        public Guid _cop_order_Code { get; set; }
        public DateTime _cop_order_CreatedTime { get; set; }
        public DateTime _cop_order_Deedline { get; set; }

        //Customer
        public Guid _cop_customer_PIN { get; set; }
        public string _cop_customer_Name { get; set; }
        public string _cop_customer_Sername { get; set; }
     
        //Product
        public Guid _cop_product_Barcode { get; set; }
        public string _cop_product_Name { get; set; }
        public string _cop_product_Description { get; set; }
        public string _cop_product_Videocard { get; set; }
        public string _cop_product_OperatingSystem { get; set; }
        public string _cop_product_Screen { get; set; }
        public string _cop_product_Prosessor { get; set; }
        public string _cop_product_Company { get; set; }
        public DateTime _cop_product_CreatedTime { get; set; }
        public double _cop_product_Price { get; set; }
       

    }
}
