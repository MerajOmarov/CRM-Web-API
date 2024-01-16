using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public  class _order_DeleteDTO_respons
    {
        public Guid _order_Code { get; set; }
        public DateTime _order_DeletedTime { get; set; }
       
    }
}
