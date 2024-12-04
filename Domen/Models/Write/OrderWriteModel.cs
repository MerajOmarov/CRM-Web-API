using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.CommandModels
{
    public class OrderWriteModel
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public DateTime Deedline { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CustomerID { get; set; }
        public CustomerWriteModel Customer { get; set; }
        public int ProductID { get; set; }
        public ProductWriteModel Product { get; set; }
    }
}
