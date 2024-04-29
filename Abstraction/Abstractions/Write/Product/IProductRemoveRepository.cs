using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductRemoveRepository
    {
        Task<ProductWriteModel> RemoveProductAsync(Guid productBarcode,
                                                   CancellationToken cancellationToken);
    }
}
