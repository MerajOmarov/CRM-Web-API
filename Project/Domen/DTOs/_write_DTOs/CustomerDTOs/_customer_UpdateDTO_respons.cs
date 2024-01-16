using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.CustomerDTOs
{
    public  class _customer_UpdateDTO_respons
    {
        public string _customer_Name { get; set; }
        public string _customer_Surname { get; set; }
        public Guid _customer_PIN { get; set; }
        public DateTime _customer_UpdatedTime { get; set; }
    }
}
