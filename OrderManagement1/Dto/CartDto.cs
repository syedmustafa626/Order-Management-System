using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class CartDto
    {
        [Required]
        public int CartId { get; set; }        
        public int? UserId { get; set; }        
        public int? ProductId { get; set; }
        public double Totalcost { get; set; }
    }
}
