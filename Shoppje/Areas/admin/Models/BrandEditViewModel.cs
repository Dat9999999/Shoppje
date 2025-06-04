using System.ComponentModel.DataAnnotations;

namespace Shoppje.Areas.admin.Models
{
    public class BrandEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public int Status { get; set; }
    }
}
