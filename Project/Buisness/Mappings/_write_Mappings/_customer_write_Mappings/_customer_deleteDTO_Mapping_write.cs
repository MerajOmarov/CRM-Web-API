using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.CommandMapping.CustomerMapping
{
    public class _customer_deleteDTO_Mapping_write:Profile
    {
        public _customer_deleteDTO_Mapping_write()
        {
            CreateMap<_customer_Model_write, _customer_DeleteDTO_respons>();
        }
    }
}
