using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.CustomerDTOs
{
    public  class UpdateCustomerResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid PIN { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
