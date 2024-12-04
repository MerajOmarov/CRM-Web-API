using Buisness.DTOs.CommandDTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.Command.Order
{
    public  class PostOrderRequest:IRequest<PostOrderResponse>
    {
        public Guid Code { get; set; }

        public Guid CustomerPIN { get; set; }

        public Guid ProductBarcode { get; set; }

        public DateTime Deedline { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
