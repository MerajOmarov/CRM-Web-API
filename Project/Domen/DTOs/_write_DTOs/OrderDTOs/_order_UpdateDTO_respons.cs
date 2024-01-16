using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public  class _order_UpdateDTO_respons
    {
        public Guid _order_Code { get; set; }
        public DateTime _order_Deedline { get; set; }
        public string _order_customer_Name { get; set; }
        public string _order_product_Name { get; set; }
        public DateTime _order_UpdatedTime { get; set; }
    }
}
