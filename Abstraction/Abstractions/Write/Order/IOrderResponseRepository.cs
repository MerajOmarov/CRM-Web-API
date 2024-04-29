using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IOrderResponseRepository
    {
        Task<OrderWriteModel> ResponseOrderAsync(Guid orderCode,
                                                 CancellationToken cancellationToken);
    }
}
