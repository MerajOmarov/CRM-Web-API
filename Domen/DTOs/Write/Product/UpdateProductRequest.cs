using Domen.DTOs.CommandDTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.Write.Product
{
    public class UpdateProductRequest:IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public int NewPrice { get; set; }
    }
}
