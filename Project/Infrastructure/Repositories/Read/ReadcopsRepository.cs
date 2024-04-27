using Abstraction.Abstractions._read_Abstractions;
using AutoMapper;
using Buisness.DTOs.Query;
using Domen.Models.CommandModels;
using Domen.Models.QueryModel;
using Infrastructure.DataContexts.QueryDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.QueryRepositories
{
    public class ReadcopsRepository : IReadcopsRepository
    {
        private readonly CompanyDbContextread _companyDbContextread;
        private readonly IMapper _mapper;

        public ReadcopsRepository(CompanyDbContextread DbContext, IMapper mapper)
        {
            _companyDbContextread = DbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<copReadDTO>> ReadCOPs(Guid CustomerPIN)
        {
            List<COPReadModel> cops = await _companyDbContextread.ClientOrderProducts.Where(x => x.CustomerPIN == CustomerPIN).ToListAsync();
            List<copReadDTO> Responses = new();
            copReadDTO Response;
            int CountOfEltities = cops.Count;
            for (int i = 0; i < CountOfEltities; i++)
            {
                Response = _mapper.Map<copReadDTO>(cops[i]);
                Responses.Add(Response);
            }

            return Responses;
        }

        public async Task<copReadDTO> ReadCOP(Guid OrderCode)
        {
            //Validation
            CheckGuid(OrderCode);

            //Entity from database 
            COPReadModel? customerOrderProductFromdb = await _companyDbContextread.ClientOrderProducts.SingleOrDefaultAsync(x => x.OrderCode == OrderCode);
            if (customerOrderProductFromdb == null)
            {
                throw new Exception("CustomerOrderProduct Error: The CustomerOrderProduct dose not exist");
            }

            // Mapping Entity to DTO
            var respons = _mapper.Map<copReadDTO>(customerOrderProductFromdb);

            return respons;

        }

        private void CheckGuid(Guid guid)
        {
            if(guid==null)
            {
                throw new Exception("Validation Error: The order_Code field can not be null");
            }
            if(!(guid.GetType() == typeof(Guid)))
            {
                throw new Exception("Validation Error: The order_Code field must be guid");
            }
        }

    }
}
