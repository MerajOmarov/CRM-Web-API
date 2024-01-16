
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Customer
{
    public class _customer_PostDTO_respons
    {
        public string _customer_Name { get; set; }
        public string _customer_Surname { get; set; }
        public Guid _customer_PIN { get; set; }
        public DateTime _customer_CreatedTime { get; set; }

    }
}
