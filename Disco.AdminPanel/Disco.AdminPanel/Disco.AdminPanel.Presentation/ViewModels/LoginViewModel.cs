using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Disco.AdminPanel.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
