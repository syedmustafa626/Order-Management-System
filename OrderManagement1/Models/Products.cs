using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public double ProductPrice { get; set; }

        public Category Category { get; set; }
        public ICollection<Cart> Cart { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
