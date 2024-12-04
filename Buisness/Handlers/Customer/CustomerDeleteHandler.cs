using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Domen.DTOs.Write.Customer;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerDeleteHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDeleteCustomer _deleteCustomer;

        public CustomerDeleteHandler(IMapper mapper, IDeleteCustomer deleteCustomer)
        {
            _mapper = mapper;
            _deleteCustomer = deleteCustomer;
        }

        public async Task<DeleteCustomerResponse> Handle(
            DeleteCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var customerFromdb = await _deleteCustomer.DeleteCustomerAsync(request, cancellationToken);

            return _mapper.Map<DeleteCustomerResponse>(customerFromdb);
        }
    }
}
