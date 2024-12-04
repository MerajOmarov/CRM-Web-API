
using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Azure;
using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerUpdateHandle : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateCustomer _updateCustomer;
        public CustomerUpdateHandle(IMapper mapper,
                                    IUpdateCustomer updateCustomer)
        {
            _mapper = mapper;
            _updateCustomer = updateCustomer;
        }

        public async Task<UpdateCustomerResponse> Handle(
            UpdateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _updateCustomer.UpdateCustomerAsync(request, cancellationToken);

            return _mapper.Map<UpdateCustomerResponse>(response);
        }
    }
}
