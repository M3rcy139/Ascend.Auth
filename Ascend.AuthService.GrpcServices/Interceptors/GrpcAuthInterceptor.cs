using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Grpc.Core.Interceptors;

namespace Ascend.AuthService.GrpcService.Interceptors;

public class GrpcAuthInterceptor : Interceptor
{
    private readonly TokenValidationParameters _tokenValidationParameters;

    public GrpcAuthInterceptor(TokenValidationParameters tokenValidationParameters)
    {
        _tokenValidationParameters = tokenValidationParameters;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var authHeader = context.RequestHeaders.FirstOrDefault(h => h.Key == "authorization");

        if (authHeader != null)
        {
            var token = authHeader.Value;
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = token.Substring("Bearer ".Length);

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out _);
                
                context.UserState["User"] = principal;
            }
            catch (Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, $"Invalid token: {ex.Message}"));
            }
        }

        return await continuation(request, context);
    }
}
