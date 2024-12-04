using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.Write.Customer
{
    public class DeleteCustomerResponse
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
