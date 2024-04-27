using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.OrderDTOs
{
    public class OrderRequestDeleteDTO:IRequest<OrderResponseDeleteDTO>
    {
        [Required(ErrorMessage = "Data Annotation Error: The Code is required")]
        public Guid Code { get; set; }
    }
}
