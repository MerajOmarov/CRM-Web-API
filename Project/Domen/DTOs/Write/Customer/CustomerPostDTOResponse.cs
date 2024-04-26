
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Customer
{
    public class CustomerPostDTOResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid PIN { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}
