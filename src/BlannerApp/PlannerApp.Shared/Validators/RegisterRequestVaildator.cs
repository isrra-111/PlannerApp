using FluentValidation;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Validators
{
    public class RegisterRequestVaildator :AbstractValidator<RegisterRequest>
    {
        public RegisterRequestVaildator()
        {
            RuleFor(p=>p.Email)
                .NotEmpty()
                .WithMessage("Email is Required")
                .EmailAddress()
                .WithMessage("Email is not a vaild email address");

            RuleFor(p=>p.FirstName)
                .NotEmpty()
                .WithMessage("First Name is Required")
                .MaximumLength(20)
                .WithMessage("First Name must be less than 25 characters.");

             RuleFor(p=>p.LastName)
                .NotEmpty()
                .WithMessage("Last Name is Required")
                .MaximumLength(20)
                .WithMessage("Last Name must be less than 25 characters.");

             RuleFor(p=>p.Password)
                .NotEmpty()
                .WithMessage("Password is Required")
                .MinimumLength(5)
                .WithMessage("Password must at least 5 characters.");

            RuleFor(p=>p.ConfirmPassword)
                .Equal(p=>p.Password)
               
                .WithMessage("Confirm Password doesn't match the password");



            
        }

    }
}
