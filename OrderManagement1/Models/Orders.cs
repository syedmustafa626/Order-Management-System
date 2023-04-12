using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
            Payment = new HashSet<Payment>();
            Shipping = new HashSet<Shipping>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? Discount { get; set; }
        public double FinalAmount { get; set; }

        public Users User { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Payment> Payment { get; set; }
        public ICollection<Shipping> Shipping { get; set; }
    }
}
