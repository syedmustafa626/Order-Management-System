using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }
        public string PaymentType { get; set; }
        public string PaymentStatus { get; set; }

        public Orders Order { get; set; }
    }
}
