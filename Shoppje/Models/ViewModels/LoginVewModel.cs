using System.ComponentModel.DataAnnotations;

namespace Shoppje.Models.ViewModels
{
    public class LoginVewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
