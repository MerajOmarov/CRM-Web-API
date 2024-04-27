using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.QueryModel
{
    public class COPReadModel
    {
        [Key]
        public int ID { get; set; }

        //Order
        public Guid OrderCode { get; set; }
        public DateTime OrderCreatedTime { get; set; }
        public DateTime OrderDeedline { get; set; }

        //Customer
        public Guid CustomerPIN { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSername { get; set; }
     
        //Product
        public Guid ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductVideocard { get; set; }
        public string ProductOperatingSystem { get; set; }
        public string ProductScreen { get; set; }
        public string ProductProsessor { get; set; }
        public string ProductCompany { get; set; }
        public DateTime ProductCreatedTime { get; set; }
        public double ProductPrice { get; set; }
       

    }
}
