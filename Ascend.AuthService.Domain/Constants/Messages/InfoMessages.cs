namespace Ascend.AuthService.Domain.Constants.Messages;

public static class InfoMessages
{
    public const string RequestProcessingComplete = 
        "Completion of request processing. Path: {Path}, Method: {Method}, StatusCode: {StatusCode}";
    
    public const string SuccessfulLogin = "Successfully logged in.";
    public const string SuccessfulRegistration = "Successfully registered a user.";
    
    public const string SuccessfulyUpdatedContactDetails = "Successfully updated contact details.";
}