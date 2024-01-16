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
    public  class _customer_UpdateDTO_request:IRequest<_customer_UpdateDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _customer_oldPIN field is required")]
        public Guid _customer_oldPIN { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _customer_newPIN field is required")]
        public Guid _customer_newPIN { get; set; }
    }
}
