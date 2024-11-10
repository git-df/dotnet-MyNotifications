using MyNotifications.Api.Endpoints.SendNotification;
using MyNotifications.DomainModel.Models;

namespace MyNotifications.UnitTests.Validators;

[TestFixture]
public class SendNotificationValidatorTests : ValidatorTests<SendNotificationRequest, SendNotificationValidator>
{
    [Test]
    public async Task SendNotificationRequest_Valid()
    {
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(result.IsValid, Is.True);
    }
    
    [Test]
    public async Task SendNotificationRequest_Invalid_Request()
    {
        Request = new SendNotificationRequest(Request: null!);
        
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x =>
            x.PropertyName == nameof(SendNotificationRequest.Request)));
    }
    
    [Test]
    public async Task SendNotificationRequest_Invalid_RequestContent()
    {
        Request.Request.Content = string.Empty;
        
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x => 
            x.PropertyName == GetName([nameof(SendNotificationRequest.Request), nameof(WebhookRequest.Content)])));
    }
}