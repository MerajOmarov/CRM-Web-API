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
    public  class OrderUpdateDTOrequest:IRequest<OrderUpdateDTOresponse>
    {
        [Required(ErrorMessage = "Data Annotation Error: The oldCode field is required")]
        public Guid oldCode { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The newDeedline field is required")]
        public DateTime newDeedline { get; set; }

        [Required(ErrorMessage = "Data Annotation Error: The newCode field is required")]
        public Guid newCode { get; set; }
    }
}
