﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTOs.CommandDTOs.Order
{
    public  class PostOrderResponse
    {
        public Guid Code { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public DateTime Deedline { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
