using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Parrot_Wings.Models
{
    public class RegisterModel
    {
        [Required] [JsonProperty("email")] public string Email { get; set; }

        [Required] [JsonProperty("name")] public string Name { get; set; }

        [Required] [JsonProperty("surname")] public string Surname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [JsonProperty("passwordConfirm")]
        public string PasswordConfirm { get; set; }
    }
}