using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs._read_DTOs
{
    public  class _product_detailed_GetDTO_respons
    {
        public string _product_Name { get; set; }
        public string _product_Description { get; set; }
        public Guid _product_Barcode { get; set; }
        public string _product_Videocard { get; set; }
        public string _product_OperatingSystem { get; set; }
        public string _product_Screen { get; set; }
        public string _product_Prosessor { get; set; }
        public double _product_Price { get; set; }
    }
}
