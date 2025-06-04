using System.ComponentModel.DataAnnotations;

namespace Shoppje.Areas.admin.Models
{
    public class BrandCreateViewModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Slug { get; set; }
        [Required(ErrorMessage = "Please select a status.")]
        public int Status { get; set; }
    }
}
