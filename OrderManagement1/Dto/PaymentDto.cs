using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class PaymentDto
    {
        [Required]
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }
    }
}
