using FluentValidation;
using B3Consultants.DB;

namespace B3Consultants.Models.Validators
{
    public class AddConsultantDTOValidator : AbstractValidator<AddConsultantDTO>
    {
        public AddConsultantDTOValidator(ConsultantDBContext dBContext)
        {
            RuleFor(x => x.FirstName).NotEmpty()
            .Length(2, 30);

            RuleFor(x => x.LastName).NotEmpty()
            .Length(2, 30);

            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.ExperienceId).NotEmpty();
            RuleFor(x => x.HourlyRatePlnNet).NotEmpty();
            RuleFor(x => x.AvailabilityId).NotEmpty();
            RuleFor(x => x.ProfileSource).NotEmpty()
                .Custom((value, context) =>
                {
                    var profileSourceInUse = dBContext.Consultants.Any(x => x.ProfileSource == value);
                    if (profileSourceInUse)
                    {
                        context.AddFailure("ProfileSource", "Profile source is already taken");
                    }
                });

        }
    }
}
