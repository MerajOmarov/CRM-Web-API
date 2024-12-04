﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models.QueryModel
{
    public class ProductReadModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Barcode { get; set; }
        public string Videocard { get; set; }
        public string OperatingSystem { get; set; }
        public string Screen { get; set; }
        public string Prosessor { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
       
    }
}
