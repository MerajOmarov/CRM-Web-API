using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public class PostCustomer :IPostCustomer
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public PostCustomer(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerWriteModel> PostCustomerAsync(CustomerWriteModel customer, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                await _dbContext.Customers.AddAsync(customer, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return customer;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
