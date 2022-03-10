using FluentValidation;
using B3Consultants.DB;
using B3Consultants.Entities;

namespace B3Consultants.Models.Validators
{
    public class ConsultantQueryValidator : AbstractValidator<ConsultantQuery>
    {
        private int[] allowedPageSizes = { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Consultant.Role), nameof(Consultant.Experience), nameof(Consultant.Availability), nameof(Consultant.HourlyRatePlnNet), nameof(Consultant.Location)};
        public ConsultantQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).Custom((value, context) =>
            {
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must be in [{string.Join(",",allowedPageSizes)}]");
                }
            });
            RuleFor(x => x.SortBy)
                .Must(value => String.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional and must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
