using FluentValidation;

namespace Application.Incident.Commands.UpdateIncident
{
    public class UpdateIncidentModelValidator : AbstractValidator<UpdateIncidentModel>
    {
        public UpdateIncidentModelValidator()
        {
            RuleFor(x => x.CallCode).NotEmpty().WithMessage("Call code is required");
            RuleFor(x => x.SubsystemCode).NotEmpty().WithMessage("Subsystem code is required");
            RuleFor(x => x.OpenedDate).NotEmpty().WithMessage("Opened date is required");
            RuleFor(x => x.ClosedDate).NotEmpty().WithMessage("Closed date is required");
            RuleFor(x => x.RequestType).NotEmpty().WithMessage("Request type is required");
            RuleFor(x => x.ApplicationType).NotEmpty().WithMessage("Application type is required");
            RuleFor(x => x.Urgency).NotEmpty().WithMessage("Urgency is required");
            RuleFor(x => x.SubCause).NotEmpty().WithMessage("Sub cause is required");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("Summary is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Solution).NotEmpty().WithMessage("Solution is required");
            RuleFor(x => x.OriginId).NotEmpty().WithMessage("Origin is required");
            RuleFor(x => x.AmbitId).NotEmpty().WithMessage("Ambit is required");
            RuleFor(x => x.IncidentTypeId).NotEmpty().WithMessage("Incident type is required");
            RuleFor(x => x.ScenarioId).NotEmpty().WithMessage("Scenario is required");
            RuleFor(x => x.ThreatId).NotEmpty().WithMessage("Threat is required");
        }
    }
}
