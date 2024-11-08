using FluentValidation;
using MyNotifications.DomainModel.Models;

namespace MyNotifications.DomainModel.Validators;

public class WebhookRequestValidator : AbstractValidator<WebhookRequest>
{
    public WebhookRequestValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull();
    }
}