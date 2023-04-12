using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class CartItemsDto
    {
        [Required]
        public int CartItemsId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int? ProductQty { get; set; }
    }
}
