using FluentValidation;

namespace MyNotifications.Sender.Extensions;

public static class ValidationExtension
{
    public static bool IsValid<T, TValidator>(this T value) where TValidator : AbstractValidator<T>, new()
    {
        var validator = new TValidator();
        return  validator.Validate(value).IsValid;
    }
}