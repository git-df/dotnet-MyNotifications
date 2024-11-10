using AutoFixture;

namespace MyNotifications.UnitTests.Validators;

public class ValidatorTests<TRequest, TValidator> where TValidator : new()
{
    protected TValidator Validator;
    protected Fixture Fixture;
    protected TRequest Request;
    
    [SetUp]
    public void SetUp()
    {
        Validator = new TValidator();
        Fixture = new Fixture();
        Request = Fixture.Create<TRequest>();
    }
    
    protected static string GetName(List<string> names)
        => string.Join('.', names);
}