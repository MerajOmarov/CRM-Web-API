using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.CustomerDTOs
{
    public class CustomerResponseDeleteDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid PIN { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
