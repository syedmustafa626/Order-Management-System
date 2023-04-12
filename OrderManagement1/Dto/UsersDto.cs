using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class UsersDto
    {
        [Required]
        public int UserId { get; set; }
        public string UserFname { get; set; }
        public string UserLname { get; set; }
        public string UserType { get; set; }
        public string UserContact { get; set; }
        public string UserCity { get; set; }
        public int PinCode { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
