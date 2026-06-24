namespace Ascend.Auth.Domain.Constants.Messages;

public static class ErrorMessages
{
    public const string FailedToLogin = "Invalid email or password.";
    public const string AlreadyExistsUserName = "A user with the same username already exists.";
    public const string AlreadyExistsEmail = "A user with the same email already exists.";
    public const string AlreadyExistsPhoneNumber = "A user with the same phone number already exists.";
    public const string UserNotActive = "Account is not active.";
    public const string InvalidRefreshToken = "Invalid or expired refresh token.";
}