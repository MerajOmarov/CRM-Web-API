﻿namespace Buisness.DTOs.Query
{
    public class GetCustomerOrderProductDto
    {
        public Guid CustomerPIN { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSername { get; set; }
        public Guid OrderCode { get; set; }
        public string OrderDeedline { get; set; }
        public Guid ProductBarcode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}
