using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement1.Dto
{
    public class GetProductsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public int? CategoryId { get; set; }
        public double ProductPrice { get; set; }

        public CategoryDto Category { get; set; }
    }
}
