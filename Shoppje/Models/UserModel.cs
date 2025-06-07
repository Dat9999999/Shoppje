using System.ComponentModel.DataAnnotations;

namespace Shoppje.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required!"), EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
    }
}
