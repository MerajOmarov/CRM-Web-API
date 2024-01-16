using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Query
{
    public class _cop_GetDTO_respons
    {
        public Guid _cop_customer_PIN { get; set; }
        public string _cop_customer_Name { get; set; }
        public string _cop_customer_Sername { get; set; }
        public Guid _cop_order_Code { get; set; }
        public string _cop_order_Deedline { get; set; }
        public Guid _cop_product_Barcode { get; set; }
        public string _cop_product_Name { get; set; }
        public string _cop_product_Description { get; set; }
        public double _cop_product_Price { get; set; }
    }
}
