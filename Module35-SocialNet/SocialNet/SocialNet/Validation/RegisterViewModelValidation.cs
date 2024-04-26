using FluentValidation;
using SocialNet.ViewModels.Account;

namespace SocialNet.Validation;

public class RegisterViewModelValidation : AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.EmailReg).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Month).NotEmpty();
        RuleFor(x => x.Year).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.PasswordReg).NotEmpty().Length(5, 8).WithMessage(string.Format("Пароль должен быть длиной минимум {1} и максимум {2} символов.", 5, 8));
        RuleFor(x => x.PasswordConfirm).NotEmpty().Matches(x => x.PasswordReg).WithMessage("Пароли не совпадают!");
        
    }
}