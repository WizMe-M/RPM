using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeWebSQL.ViewModels
{
    public class RegistrationAccountModel
    {
        [Required(ErrorMessage = "Не указана электронная почта!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
        
        [Display(Name = "Логин")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Не указан пароль!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Пароль не подтверждён!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmedPassword { get; set; }
        
        [Required(ErrorMessage = "Не указано имя пользователя!")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Не указана фамилия пользователя!")]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }
        
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Не указана дата рождения пользователя!")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }
}