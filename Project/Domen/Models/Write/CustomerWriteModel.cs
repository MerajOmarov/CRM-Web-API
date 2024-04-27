using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.CommandModels
{
    public class CustomerWriteModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid PIN { get; set; }
        public DateTime CreatedTime { get; set; }

        //Navigation parametr
        public IEnumerable<OrderWriteModel> OrdersOfCustomer { get; set; }
    }
}
