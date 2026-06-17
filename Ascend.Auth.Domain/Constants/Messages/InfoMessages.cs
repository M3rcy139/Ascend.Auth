namespace Ascend.Auth.Domain.Constants.Messages;

public static class InfoMessages
{
    public const string RequestProcessingComplete = 
        "Completion of request processing. Path: {Path}, Method: {Method}, StatusCode: {StatusCode}";
    
    public const string SuccessfulLogin = "Successfully logged in.";
    public const string SuccessfulRegistration = "Successfully registered a user.";
    public const string SuccessfulLogout = "Successfully logged out.";
    public const string SuccessfulRefresh = "Token refreshed successfully.";
    public const string RoleAssigned = "Role assigned successfully.";
    
    public const string SuccessfullyUpdatedContactDetails = "Successfully updated contact details.";
}