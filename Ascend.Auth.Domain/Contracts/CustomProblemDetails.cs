using Microsoft.AspNetCore.Mvc;

namespace Ascend.Auth.Domain.Contracts;

public class CustomProblemDetails : ProblemDetails
{
    public IEnumerable<object> Errors { get; set; }
}