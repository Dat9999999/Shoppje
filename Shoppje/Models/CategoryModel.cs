using System.ComponentModel.DataAnnotations;

namespace Shoppje.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id {get; set; }
        [Required, MinLength(4, ErrorMessage = "Category's name is required!")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Category's description is required!")]
        public string Description { get; set; }
        [Required]
        public String slug { get; set; }
        public int Status { get; set; }

    }
}
