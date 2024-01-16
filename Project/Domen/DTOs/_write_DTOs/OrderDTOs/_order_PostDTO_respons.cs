using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Order
{
    public  class _order_PostDTO_respons
    {
        public Guid _order_Code { get; set; }
        public string _order_customer_Name { get; set; }
        public string _order_product_Name { get; set; }
        public DateTime _order_Deedline { get; set; }
        public DateTime _order_CreatedTime { get; set; }
    }
}
