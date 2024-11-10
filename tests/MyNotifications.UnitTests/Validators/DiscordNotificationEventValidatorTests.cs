using MyNotifications.DomainModel.Events;
using MyNotifications.DomainModel.Models;
using MyNotifications.DomainModel.Validators;

namespace MyNotifications.UnitTests.Validators;

[TestFixture]
public class DiscordNotificationEventValidatorTests : ValidatorTests<DiscordNotificationEvent, DiscordNotificationEventValidator>
{
    [Test]
    public async Task DiscordNotificationEvent_Valid()
    {
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public async Task DiscordNotificationEvent_Invalid_Id()
    {
        Request = Request with { Id = Guid.Empty };

        var result = await Validator.ValidateAsync(Request);

        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x =>
            x.PropertyName == nameof(DiscordNotificationEvent.Id)));
    }

    [Test]
    public async Task DiscordNotificationEvent_Invalid_Request()
    {
        Request = Request with { Request = null! };
        
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x =>
            x.PropertyName == nameof(DiscordNotificationEvent.Request)));
    }
    
    [Test]
    public async Task DiscordNotificationEvent_Invalid_RequestContent()
    {
        Request.Request.Content = string.Empty;
        
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x => 
            x.PropertyName == GetName([nameof(DiscordNotificationEvent.Request), nameof(WebhookRequest.Content)])));
    }
}