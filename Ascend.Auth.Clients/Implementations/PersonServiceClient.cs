using Ascend.Auth.Clients.Interfaces;
using Ascend.Grpc.Person;

namespace Ascend.Auth.Clients.Implementations;

public class PersonServiceClient : IPersonServiceClient
{
    private readonly PersonService.PersonServiceClient _client;

    public PersonServiceClient(PersonService.PersonServiceClient client)
    {
        _client = client;
    }

    public async Task CreatePersonAsync(Guid personId)
    {
        var request = new CreatePersonRequest
        {
            PersonId = personId.ToString(),
        };

        var response = await _client.CreatePersonAsync(request);

        if (!response.Success)
        {
            throw new Exception("Failed to create person via gRPC.");
        }
    }
}