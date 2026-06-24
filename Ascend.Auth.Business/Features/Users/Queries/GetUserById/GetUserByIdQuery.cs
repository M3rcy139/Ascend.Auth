using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Models;
using MediatR;

namespace Ascend.Auth.Business.Features.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<User>;

public class GetUserByIdQueryHandler(IUserRepository userRepository)
    : IRequestHandler<GetUserByIdQuery, User>
{
    public async Task<User> Handle(GetUserByIdQuery query, CancellationToken ct)
    {
        return await userRepository.GetUserByIdAsync(query.UserId)
            ?? throw new NotFoundException("User not found.");
    }
}


