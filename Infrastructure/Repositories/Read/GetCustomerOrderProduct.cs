using Abstraction.Abstractions.Read;
using AutoMapper;
using Buisness.DTOs.Query;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.QueryRepositories
{
    public class GetCustomerOrderProduct : IGetCustomerObjectProduct
    {
        private readonly CompanyReadDbContext _companyDbContextread;
        private readonly IMapper _mapper;

        public GetCustomerOrderProduct(CompanyReadDbContext dbContext, IMapper mapper)
        {
            _companyDbContextread = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCustomerOrderProductDto>> GetCOPsAsync(int id,
                                                                CancellationToken cancellationToken)
        {

            List<CustomerOrderProductReadModel> cops = await _companyDbContextread.ClientOrderProducts
                .Where(x => x.OrderId == id)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            List<GetCustomerOrderProductDto> responses = new();

            GetCustomerOrderProductDto response;

            int CountOfEltities = cops.Count;

            for (int i = 0; i < CountOfEltities; i++)
            {
                response = _mapper.Map<GetCustomerOrderProductDto>(cops[i]);

                responses.Add(response);
            }

            return responses;
        }

        public async Task<GetCustomerOrderProductDto> GetCOPAsync(int id, CancellationToken cancellationToken)
        {
            CustomerOrderProductReadModel? customerOrderProductFromdb = await _companyDbContextread.ClientOrderProducts
                .SingleOrDefaultAsync(x => x.OrderId == id);

            if (customerOrderProductFromdb == null)
                throw new Exception("CustomerOrderProduct Error: The CustomerOrderProduct dose not exist");

            var response = _mapper.Map<GetCustomerOrderProductDto>(customerOrderProductFromdb);

            return response;
        }
    }
}
