using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string UserType { get; set; }
        public string UserContact { get; set; }
        public string UserCity { get; set; }
        public int PinCode { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
