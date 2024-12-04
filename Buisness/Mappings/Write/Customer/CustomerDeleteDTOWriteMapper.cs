﻿using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.Write.Customer;
using Domen.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Mappings.Write.Customer
{
    public class CustomerDeleteDTOWriteMapper:Profile
    {
        public CustomerDeleteDTOWriteMapper()
        {
            CreateMap<CustomerWriteModel, DeleteCustomerResponse>();
        }
    }
}
