using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Buisness.Handlers.Customer
{
    public class CustomerPostHandler : IRequestHandler<PostCustomerRequest, PostCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCustomer _postCustomer;

        public CustomerPostHandler(IMapper mapper,
                                   IPostCustomer postCustomer)
        {
            _mapper = mapper;
            _postCustomer = postCustomer;
        }

        public async Task<PostCustomerResponse> Handle(
            PostCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerWriteModel>(request);

            var response  =  await _postCustomer.PostCustomerAsync(customer, cancellationToken);

            return _mapper.Map<PostCustomerResponse>(request);
        }
    }
}
