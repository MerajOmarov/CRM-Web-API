using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public  class OrderUpdateDTOresponse
    {
        public Guid Code { get; set; }
        public DateTime Deedline { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
