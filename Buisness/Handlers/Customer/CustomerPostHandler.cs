using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerPostHandler : IRequestHandler<CustomerRequestPostDTO, CustomerResponsePostDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerRequestPostDTO> _validator;
        private readonly ICustomerPostRepository _repositoryPost;
        private readonly ICustomerResponseRepository _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerPostHandler(
            IMapper mapper,
            IValidator<CustomerRequestPostDTO> validator,
            ICustomerPostRepository repositoryPost,
            ICustomerResponseRepository repositoryResponse,
            IUnitOfWork unitOfWork)
        {
           _mapper = mapper;
           _validator = validator;
           _repositoryPost = repositoryPost;
           _repositoryResponse = repositoryResponse;
           _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResponsePostDTO> Handle(
            CustomerRequestPostDTO request,
            CancellationToken cancellationToken)
        {
            //Validation
            var result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Mapping DTO to Entity
            var customerTodb = _mapper.Map<CustomerWriteModel>(request);

            // Adding to database
            await _repositoryPost.PostCustomerAsync(customerTodb, cancellationToken);

            //Saving changes
            await _unitOfWork.SaveAsync(cancellationToken);

            //Result
            var customerFromdb = await _repositoryResponse.ResponseCustomerAsync(customerTodb.PIN,cancellationToken);

            // Mapping Entity to DTO
            var response = _mapper.Map<CustomerResponsePostDTO>(customerFromdb);

            //Response
            return response;
        }
    }
}
