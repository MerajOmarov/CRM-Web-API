namespace Abstraction.Abstractions.Write.Customer
{
    public interface ICustomerUpdateRepository
    {
        Task UpdateCustomerAsync(Guid customerOldPIN, Guid customerNewPIN, CancellationToken cancellationToken);
    }
}
