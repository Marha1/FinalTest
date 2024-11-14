namespace FinalTestDomain.Primitives;

public static class ValidationMessages
{
    public const string NotNullOrEmpty = "{PropertyName} cannot be null or empty.";
    public const string InvalidEmailFormat = "{PropertyName} has an invalid format.";
    public const string ValueOutOfRange = "{PropertyName} must be between {From} and {To}.";
    public const string LessThanCurrentDate = "{PropertyName} must not be in the future.";
    public const string MinLessThanMax = "{PropertyName} must be less than {ComparisonValue}.";
}