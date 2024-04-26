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
    public  class CustomerPostDTORequest:IRequest<CustomerPostDTOResponse>
    {
        [Required(ErrorMessage = "Data Annotation Error: The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The Surname field is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The PIN field is required")]
        public Guid PIN { get; set; }
    }
}
