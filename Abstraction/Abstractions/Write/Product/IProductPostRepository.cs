using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductPostRepository
    {
        Task PostProductAsync(ProductWriteModel model,
                              CancellationToken cancellationToken);
    }
}
