using System;
using System.Collections.Generic;

namespace OrderManagement1.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
