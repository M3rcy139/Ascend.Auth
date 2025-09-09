namespace Ascend.Auth.Domain.Constants.Messages;

public static class ErrorMessages
{
    public const string ArgumentativeException = "An argumentative exception: {0}";
    public const string InvalidOperationException = "An invalid operation exception: {0}";
    
    public const string ValidationFailed = "Validation error: {0}";

    public const string UnexpectedErrorWithMessage = "Unexpected error: {0}";
    
    public const string FailedToLogin = "Invalid email or password.";
    public const string AlreadyExistsUserName = "A user with the same username already exists.";
    public const string AlreadyExistsEmail = "A user with the same email already exists.";
    public const string AlreadyExistsPhoneNumber = "A user with the same phone number already exists.";
    public const string UserNotFound = "User not found.";
    
    public const string ContactDetailNotFound = "Contact detail not found.";
    
    public const string PersonNotFound = "Person not found.";
    
    public const string StatValueNotFound = "Stat value not found.";
    public const string SubStatValueNotFound = "SubStatValue not found.";
}