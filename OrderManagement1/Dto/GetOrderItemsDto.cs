using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class GetOrderItemsDto
    {
        
        public int OrderItemId { get; set; }
        //public int? ProductId { get; set; }
        public double ProductPrice { get; set; }
        //public int? OrderId { get; set; }
        public int? ProductQty { get; set; }

       

        public OrdersDto Order { get; set; }
        public ProductsDto Product { get; set; }
    }
}
