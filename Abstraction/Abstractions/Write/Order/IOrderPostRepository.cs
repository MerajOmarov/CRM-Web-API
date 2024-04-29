using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IOrderPostRepository
    {
        Task PostOrderAsync(OrderWriteModel model,
                            CancellationToken cancellationToken);
    }
}
