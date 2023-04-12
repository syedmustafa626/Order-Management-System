using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class OrderItems
    {
        public int OrderItemId { get; set; }
        public int? ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int? OrderId { get; set; }
        public int? ProductQty { get; set; }

        public Orders Order { get; set; }
        public Products Product { get; set; }
    }
}
