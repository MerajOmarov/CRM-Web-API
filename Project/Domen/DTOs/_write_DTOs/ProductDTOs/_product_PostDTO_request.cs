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
    public  class _product_PostDTO_request:IRequest<_product_PostDTO_respons>
    {
        [Required(ErrorMessage = "Data Annotation Error: The _product_Name field is required")]
        public string _product_Name { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Description field is required")]
        public string _product_Description { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Videocard field is required")]
        public string _product_Videocard { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_OperatingSystem field is required")]
        public string _product_OperatingSystem { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Screen field is required")]
        public string _product_Screen { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Prosessor field is required")]
        public string _product_Prosessor { get; set; }
      

        [Required(ErrorMessage = "Data Annotation Error: The _product_Price field is required")]
        public double _product_Price { get; set; }

        public string _product_Company { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_Barcode field is required")]
        public Guid _product_Barcode { get; set; }


        [Required(ErrorMessage = "Data Annotation Error: The _product_CreatedTime field is required")]
        public DateTime _product_CreatedTime { get; set; }
    }
}
