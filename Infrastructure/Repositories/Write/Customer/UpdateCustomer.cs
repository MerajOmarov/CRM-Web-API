using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories.CommandRepositories.CustomerRepository
{
    public  class UpdateCustomer: IUpdateCustomer
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomer(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerWriteModel> UpdateCustomerAsync(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                CustomerWriteModel? customer = await _dbContext.Customers.SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                
                customer!.PhoneNumber = request.PhoneNumber;
                
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
