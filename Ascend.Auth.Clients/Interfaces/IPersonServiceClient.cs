namespace Ascend.Auth.Clients.Interfaces;

public interface IPersonServiceClient
{
    Task CreatePersonAsync(Guid personId);
}