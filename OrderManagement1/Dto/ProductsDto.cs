

using System.ComponentModel.DataAnnotations;

namespace OrderManagement1.Dto
{
    public class ProductsDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2)]
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public double ProductPrice { get; set; }

        //public CategoryDto Category { get; set; }
    }
}
