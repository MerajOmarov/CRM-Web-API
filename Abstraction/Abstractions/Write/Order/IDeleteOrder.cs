using Domen.DTOs.Write.Order;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IDeleteOrder
    {
        Task<DeleteOrderResponse> DeleteOrderAsync(DeleteOrderRequest request, CancellationToken cancellationToken);
    }
}
