using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs.CommandDTOs.ProductDTOs
{
    public class _product_DeleteDTO_respons
    {
        public string _product_Name { get; set; }
        public string _product_Description { get; set; }
        public Guid _product_Barcode { get; set; }
        public double _product_Price { get; set; }
        public DateTime _product_DeletedTime { get; set; }
     
    }
}
