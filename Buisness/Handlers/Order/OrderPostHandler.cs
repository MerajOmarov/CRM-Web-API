using Abstraction.Abstractions.Write.Order;
using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.Models.CommandModels;
using MediatR;

namespace Buisness.Handlers.Order
{
    public class OrderPostHandler : IRequestHandler<PostOrderRequest, PostOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostOrder _repositoryPost;

        public OrderPostHandler(IMapper mapper, IPostOrder repositoryPost)
        {
            _mapper = mapper;
            _repositoryPost = repositoryPost;
        }

        public async Task<PostOrderResponse> Handle(
            PostOrderRequest request,
            CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderWriteModel>(request);

            var response = await _repositoryPost.PostOrderAsync(order, cancellationToken);

            return _mapper.Map <PostOrderResponse>(response);
        }
    }
}
