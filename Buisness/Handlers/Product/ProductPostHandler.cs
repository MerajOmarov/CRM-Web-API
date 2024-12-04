using Abstraction.Abstractions.Write.Product;
using AutoMapper;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductPostHandler : IRequestHandler<PostProductRequest, PostProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostProduct  _postProduct;

        public ProductPostHandler(IMapper mapper, IPostProduct postProduct)
        {
            _mapper = mapper;
            _postProduct = postProduct;
        }

        public async Task<PostProductResponse> Handle(
            PostProductRequest request,
            CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductWriteModel>(request);

            var response = await _postProduct.PostProductAsync(product, cancellationToken);

            return _mapper.Map<PostProductResponse>(response);
        }
    }
}
