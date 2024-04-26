using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.ProductDTOs
{
    public  class ProductPostDTOresponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Barcode { get; set; }
        public double Price { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
