﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Data.Entity.Model.OrderAggregate
{
    public class OrderItem
    {
        public int Id { get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
    }
}
