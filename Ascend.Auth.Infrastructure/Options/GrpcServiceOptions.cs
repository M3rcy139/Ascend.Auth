namespace Ascend.Auth.Infrastructure.Options;

public class GrpcServiceOptions
{
    public const string Section = "GrpcServices";

    public string? PersonService { get; set; }
}