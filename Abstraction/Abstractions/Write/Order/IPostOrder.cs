using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Order
{
    public interface IPostOrder
    {
        Task<OrderWriteModel> PostOrderAsync(OrderWriteModel model,
                            CancellationToken cancellationToken);
    }
}
