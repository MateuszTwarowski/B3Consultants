using FluentValidation;
using B3Consultants.DB;

namespace B3Consultants.Models.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator(ConsultantDBContext dbContext)
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .Length(2, 30);

            RuleFor(x => x.LastName).NotEmpty()
                .Length(2, 30);

            RuleFor(x => x.Email).NotEmpty()
                .Length(6, 50)
                .EmailAddress()
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(x => x.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.PhoneNumber).NotEmpty()
                .Length(9, 12);

            RuleFor(x => x.PasswordHash).NotEmpty()
                .Length(5, 40);

            RuleFor(x => x.ConfirmPasswordHash).NotEmpty()
                .Equal(y => y.PasswordHash);

            RuleFor(x => x.UserRoleId).NotEmpty();
        }
    }
}
