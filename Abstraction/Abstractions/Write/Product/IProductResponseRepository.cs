using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductResponseRepository
    {
        Task<ProductWriteModel> ResponseProductAsync(Guid productBarcode,
                                                     CancellationToken cancellationToken);
    }
}
