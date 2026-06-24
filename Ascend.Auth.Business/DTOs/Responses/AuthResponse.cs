namespace Ascend.Auth.Business.DTOs.Responses;

public record AuthResponse(string AccessToken, string RefreshToken, DateTime RefreshTokenExpiresAt, Guid UserId, Guid PersonId);
