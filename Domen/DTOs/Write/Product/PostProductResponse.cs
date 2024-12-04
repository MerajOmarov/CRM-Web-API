using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.ProductDTOs
{
    public  class PostProductResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid Barcode { get; set; }
    }
}
