using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.Write.Order
{
    public class DeleteOrderRequest:IRequest<DeleteOrderResponse>
    {
        public int Id { get; set; }
    }
}
