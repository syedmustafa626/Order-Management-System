using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class GetShippingDto
    {
        public int ShippingId { get; set; }
        public int? OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingCompany { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingStatus { get; set; }

        public OrdersDto Order { get; set; }
    }
}
