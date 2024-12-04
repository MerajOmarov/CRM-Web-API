
using Abstraction;
using Abstraction.Abstractions.Write.Product;
using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.DTOs.Write.Product;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductUpdateHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateProduct  _updateProduct;

        public ProductUpdateHandler(IMapper mapper, IUpdateProduct updateProduct)
        {
            _mapper = mapper;
            _updateProduct = updateProduct;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _updateProduct.UpdateProductAsync(request, cancellationToken);

            return _mapper.Map<UpdateProductResponse>(response);                                          
        }
    }
}
