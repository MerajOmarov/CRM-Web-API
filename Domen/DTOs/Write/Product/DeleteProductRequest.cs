using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.Write.Product
{
    public class DeleteProductRequest:IRequest<DeleteProductResponse>
    {
        public int Id { get; set; }
    }
}
