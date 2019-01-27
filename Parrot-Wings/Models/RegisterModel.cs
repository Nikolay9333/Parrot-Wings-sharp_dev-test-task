using System.ComponentModel.DataAnnotations;

namespace Parrot_Wings.Models
{
    public class RegisterModel
    {
        [Required] public string Email { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string Surname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}