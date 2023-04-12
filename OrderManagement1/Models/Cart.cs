using System;
using OrderManagement1.Models;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItems>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public double Totalcost { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
