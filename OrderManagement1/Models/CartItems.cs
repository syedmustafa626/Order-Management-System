using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class CartItems
    {
        public int CartItemsId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int? ProductQty { get; set; }

        public Cart Cart { get; set; }
        public Products Product { get; set; }
    }
}
