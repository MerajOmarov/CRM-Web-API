using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.CustomerDTOs
{
    public  class _customer_DeleteDTO_request:IRequest<_customer_DeleteDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: _customer_PIN field is required")]
        public Guid _customer_PIN { get; set; }
    }
}
