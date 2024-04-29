namespace Abstraction.Abstractions.Write.Order
{
    public interface IOrderUpdateRepository
    {
        Task UpdateOrderAsync(Guid orderOldCode,
                              Guid orderNewCode,
                              DateTime orderNewDeedline,
                              CancellationToken cancellationToken);
    }
}
