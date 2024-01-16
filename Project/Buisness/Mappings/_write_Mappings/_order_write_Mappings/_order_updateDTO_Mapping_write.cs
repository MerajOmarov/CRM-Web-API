using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.OrderMapping
{
    public  class _order_updateDTO_Mapping_write:Profile
    {
        public _order_updateDTO_Mapping_write()
        {
            CreateMap<_order_Model_write, _order_UpdateDTO_respons>();
        }
    }
}
