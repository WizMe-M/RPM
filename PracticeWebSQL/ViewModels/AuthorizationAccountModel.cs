using System.ComponentModel.DataAnnotations;

namespace PracticeWebSQL.ViewModels
{
    public class AuthorizationAccountModel
    {
        [Required(ErrorMessage = "Не введен логин")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Не введен пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}