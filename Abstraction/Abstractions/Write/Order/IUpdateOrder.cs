using Buisness.DTOs.Command.Order;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IUpdateOrder
    {
        Task<OrderWriteModel> UpdateOrderAsync(UpdateOrderRequest request, CancellationToken cancellationToken);
    }
}
