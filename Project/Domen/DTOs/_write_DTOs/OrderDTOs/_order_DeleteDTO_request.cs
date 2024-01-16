using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public class _order_DeleteDTO_request:IRequest<_order_DeleteDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _order_Code is required")]
        public Guid _order_Code { get; set; }
    }
}
