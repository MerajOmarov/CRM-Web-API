using Buisness.DTOs.CommandDTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Customer
{
    public  class _customer_PostDTO_request:IRequest<_customer_PostDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _customer_Name field is required")]
        public string _customer_Name { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _customer_Surname field is required")]
        public string _customer_Surname { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _customer_PIN field is required")]
        public Guid _customer_PIN { get; set; }
    }
}
