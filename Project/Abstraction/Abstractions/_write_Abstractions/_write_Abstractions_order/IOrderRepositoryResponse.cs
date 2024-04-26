using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._write_Abstractions._write_Abstractions_order
{
    public interface IOrderRepositoryResponse
    {
        Task<OrderModelwrite> ResponseOrder(Guid order_Code);
    }
}
