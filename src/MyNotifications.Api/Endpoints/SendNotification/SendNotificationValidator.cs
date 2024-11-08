using FastEndpoints;
using FluentValidation;
using MyNotifications.DomainModel.Validators;

namespace MyNotifications.Api.Endpoints.SendNotification;

public class SendNotificationValidator : Validator<SendNotificationRequest>
{
    public SendNotificationValidator()
    {
        RuleFor(x => x.Request)
            .SetValidator(new WebhookRequestValidator())
            .NotNull();
    }
}