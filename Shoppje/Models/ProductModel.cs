using System.ComponentModel.DataAnnotations;

namespace Shoppje.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Product's name is required!")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Product's description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product's price is required!")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }

        public String slug { get; set; }

        public string Img { get; set; }

    }
}
