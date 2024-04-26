using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.CustomerDTOs
{
    public  class CustomerDeleteDTORequest:IRequest<CustomerDeleteDTORespons>
    {
        [Required(ErrorMessage = "Data Annotation Error: PIN field is required")]
        public Guid PIN { get; set; }
    }
}
