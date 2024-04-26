using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public  class OrderDeleteDTOresponse
    {
        public Guid OrderCode { get; set; }
        public DateTime DeletedTime { get; set; }
       
    }
}
