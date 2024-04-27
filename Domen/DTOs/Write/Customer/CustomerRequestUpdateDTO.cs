using Domen.DTOs.CommandDTOs.CustomerDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Customer
{
    public  class CustomerRequestUpdateDTO:IRequest<CustomerResponseUpdateDTO>
    {
        [Required(ErrorMessage = "Data Annotation Error: The oldPIN field is required")]
        public Guid oldPIN { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The newPIN field is required")]
        public Guid newPIN { get; set; }
    }
}
