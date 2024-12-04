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
    public  class UpdateOrderRequest:IRequest<UpdateOrderResponse>
    {
        public int Id { get; set; }

        public DateTime newDeedline { get; set; }

        public Guid newCode { get; set; }
    }
}
