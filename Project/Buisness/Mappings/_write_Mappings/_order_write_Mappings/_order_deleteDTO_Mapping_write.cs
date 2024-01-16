using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.OrderMapping
{
    public class _order_deleteDTO_Mapping_write:Profile
    {
        public _order_deleteDTO_Mapping_write()
        {
            CreateMap<_order_Model_write, _order_DeleteDTO_respons>();
        }
    }
}
