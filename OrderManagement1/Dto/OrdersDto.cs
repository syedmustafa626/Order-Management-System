using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class OrdersDto
    {
        [Required]
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? Discount { get; set; }
        public double FinalAmount { get; set; }
    }
}
