using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.CommandModels
{
    public class _customer_Model_write
    {
        [Key]
        public int _customer_ID { get; set; }
        public string _customer_Name { get; set; }
        public string _customer_Surname { get; set; }
        public Guid _customer_PIN { get; set; }
        public DateTime _customer_CreatedTime { get; set; }

        //Navigation parametr
        public IEnumerable<_order_Model_write> _orders_Of_customer_ { get; set; }
    }
}
