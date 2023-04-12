using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Shipping
    {
        public int ShippingId { get; set; }
        public int? OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingStatus { get; set; }

        public Orders Order { get; set; }
    }
}
