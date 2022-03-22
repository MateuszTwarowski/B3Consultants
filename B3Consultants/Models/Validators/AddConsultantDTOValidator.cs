using FluentValidation;
using B3Consultants.DB;

namespace B3Consultants.Models.Validators
{
    public class AddConsultantDTOValidator : AbstractValidator<AddConsultantDTO>
    {
        public AddConsultantDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty")
            .Length(2, 30).WithMessage("Firstname should be 2 to 30 characters long");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty")
            .Length(2, 30).WithMessage("Lastname should be 2 to 30 characters long");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role cannot be empty");

            RuleFor(x => x.ExperienceId).NotEmpty().WithMessage("Experience cannot be empty");

            RuleFor(x => x.HourlyRatePlnNet).NotEmpty().WithMessage("Hourly rate cannot be empty");

            RuleFor(x => x.AvailabilityId).NotEmpty().WithMessage("Availability cannot be empty");

            RuleFor(x => x.ProfileSource).NotEmpty().WithMessage("Profile source cannot be empty")
                .MinimumLength(5).WithMessage("Profile source should be minimum 5 characters long");
        }
    }
}
