using MyNotifications.DomainModel.Models;
using MyNotifications.DomainModel.Validators;

namespace MyNotifications.UnitTests.Validators;

public class WebhookRequestTests : ValidatorTests<WebhookRequest, WebhookRequestValidator>
{
    [Test]
    public async Task WebhookRequest_Valid()
    {
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(result.IsValid, Is.True);
    }
    
    [Test]
    public async Task WebhookRequest_Invalid_Content()
    {
        Request.Content = string.Empty;
        
        var result = await Validator.ValidateAsync(Request);
        
        Assert.That(!result.IsValid);
        Assert.That(result.Errors.Exists(x => 
            x.PropertyName == nameof(WebhookRequest.Content)));
    }
}