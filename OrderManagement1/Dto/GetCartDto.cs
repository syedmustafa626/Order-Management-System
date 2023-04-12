using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class GetCartDto
    {
        public int CartId { get; set; }
        //public int? UserId { get; set; }
        //public int? ProductId { get; set; }
        public double Totalcost { get; set; }

       

        public ProductsDto Product { get; set; }
        public UsersDto User { get; set; }
        
    }
}
