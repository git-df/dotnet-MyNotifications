using FluentValidation;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.DomainModel.Validators;

public class DiscordNotificationEventValidator : AbstractValidator<DiscordNotificationEvent>
{
    public DiscordNotificationEventValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Request)
            .SetValidator(new WebhookRequestValidator())
            .NotNull();
    }
}