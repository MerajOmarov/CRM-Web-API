using Domen.DTOs.CommandDTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Product
{
    public  class PostProductRequest:IRequest<PostProductResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Videocard { get; set; }

        public string OperatingSystem { get; set; }

        public string Screen { get; set; }

        public string Prosessor { get; set; }
      
        public double Price { get; set; }

        public string Company { get; set; }

        public Guid Barcode { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
