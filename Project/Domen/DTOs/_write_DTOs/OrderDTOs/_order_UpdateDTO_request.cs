using Domen.DTOs.CommandDTOs.OrderDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Order
{
    public  class _order_UpdateDTO_request:IRequest<_order_UpdateDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _order_oldCode field is required")]
        public Guid _order_oldCode { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _order_newDeedline field is required")]
        public DateTime _order_newDeedline { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The _order_newCode field is required")]
        public Guid _order_newCode { get; set; }
    }
}
