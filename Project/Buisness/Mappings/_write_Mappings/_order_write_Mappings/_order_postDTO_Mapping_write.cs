using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.OrderMapping
{
    public class _order_postDTO_Mapping_write : Profile
    {
        public _order_postDTO_Mapping_write()
        {
            CreateMap<_order_PostDTO_request, _order_Model_write>();
            CreateMap<_order_Model_write, _order_PostDTO_respons>();
        }
    }
}
