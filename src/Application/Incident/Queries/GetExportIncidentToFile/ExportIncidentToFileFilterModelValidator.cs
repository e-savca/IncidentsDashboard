using FluentValidation;

namespace Application.Incident.Queries.GetExportIncidentToFile
{
    public class ExportIncidentToFileFilterModelValidator : AbstractValidator<ExportIncidentToFileFilterModel>
    {
        public ExportIncidentToFileFilterModelValidator()
        {
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start date cannot be greater than end date")
                .NotEmpty().WithMessage("Start date is required");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("End date is required");

        }
    }
}
