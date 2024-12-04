using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using Azure.Core;
using Domen.DTOs.Write.Customer;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class DeleteCustomer: IDeleteCustomer
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomer(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerWriteModel> DeleteCustomerAsync(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                CustomerWriteModel? customer = await _dbContext.Customers.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                _dbContext.Customers.Remove(customer!);

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return customer!;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
