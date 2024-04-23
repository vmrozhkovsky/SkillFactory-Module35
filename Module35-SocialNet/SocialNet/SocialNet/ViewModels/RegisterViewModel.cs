using System.ComponentModel.DataAnnotations;

namespace SocialNet.Models;

public class RegisterViewModel
{
    [Display(Name = "Имя")]
    public string FirstName { get; set; }
    
    [Display(Name = "Фамилия")]
    public string LastName { get; set; }
    
    [Display(Name = "Email")]
    public string EmailReg { get; set; }
    
    [Display(Name = "Год")]
    public int Year { get; set; }

    [Display(Name = "День")]
    public int Date { get; set; }
    
    [Display(Name = "Месяц")]
    public int Month { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    //[StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
    public string PasswordReg { get; set; }
    
    //[Compare("PasswordReg", ErrorMessage = "Пароли не совпадают")]
    [DataType(DataType.Password)]
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; }

    [Required]
    [Display(Name = "Никнейм")]
    public string Login { get; set; }
}