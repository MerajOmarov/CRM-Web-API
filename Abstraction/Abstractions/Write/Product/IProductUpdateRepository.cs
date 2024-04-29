namespace Abstraction.Abstractions.Write.Product
{
    public interface IProductUpdateRepository
    {
        Task UpdateProductAsync(Guid productOldBarcode,
                                Guid? productNewpBarcode,
                                double? productNewPrice,
                                CancellationToken cancellationToken);
    }
}
