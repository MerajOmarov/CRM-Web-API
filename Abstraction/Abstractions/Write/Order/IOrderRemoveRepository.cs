using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IOrderRemoveRepository
    {
        Task<OrderWriteModel> RemoveOrderAsync(Guid orderCode,
                                               CancellationToken cancellationToken);
    }
}
