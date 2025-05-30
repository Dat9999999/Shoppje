using Shoppje.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoppje.Areas.admin.Models
{
    public class ProductCreateViewModel
    {
        [Required, MinLength(4, ErrorMessage = "Product's name is required!")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Product's description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product's price is required!")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public String slug { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
