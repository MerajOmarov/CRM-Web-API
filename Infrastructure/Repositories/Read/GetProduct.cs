using Abstraction.Abstractions.Read;
using AutoMapper;
using Domen.DTOs._read_DTOs;
using Domen.DTOs.QueryDTO;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.QueryRepositories
{
    public  class GetProduct: IGetProduct
    {
        private readonly ClientReadDbContext _DbContext;
        private readonly IMapper _mapper;

        public GetProduct(ClientReadDbContext client_DbContext_read, IMapper mapper)
        {
            _DbContext = client_DbContext_read;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductDto>> GetProductsAsync(double? ProductPrice, CancellationToken cancellationToken)
        {
            List<ProductReadModel> Products;

            if (ProductPrice!=null) 
            {
                Products = await _DbContext.Products
               .Where(x=>x.Price==ProductPrice)
               .Select(x => new ProductReadModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Barcode = x.Barcode
                })
               .ToListAsync();
            }
            else
            {
               Products = await _DbContext.Products
               .Select(x => new ProductReadModel
               {
                   Name = x.Name,
                   Description = x.Description,
                   Price = x.Price,
                   Barcode = x.Barcode
               })
              .ToListAsync();
            }
            
            List<GetProductDto> allResponses = new();  

            GetProductDto response;

            int countOfallEltitiesFromDb = Products.Count;

            for (int i = 0; i < countOfallEltitiesFromDb; i++)
            {
                response = _mapper.Map<GetProductDto>(Products[i]);

                allResponses.Add(response);
            }

            return allResponses;
        }

        public async Task<GetProductDetailedDto> GetProductAsync(Guid ProductBarcode, CancellationToken cancellationToken)
        {
            GetProductDetailedDto response;

            ProductReadModel? entityFromdb= await _DbContext.Products
                .SingleOrDefaultAsync(x=>x.Barcode==ProductBarcode);

            response = _mapper.Map<GetProductDetailedDto>(entityFromdb);

            return response;
        }
    }
}
