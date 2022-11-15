using System.ComponentModel.DataAnnotations;

namespace Disco.AdminPanel.Models
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Email is requared")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requared")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
