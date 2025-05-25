using System.ComponentModel.DataAnnotations;

namespace Shoppje.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Brand's name is required!")]
        public string Name { get; set; }
        [Required, MinLength(4, ErrorMessage = "Brand's description is required!")]
        public string Description { get; set; }
        [Required]
        public String Slug { get; set; }
        public int Status { get; set; }
    }
}
