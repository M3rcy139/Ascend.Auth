using Microsoft.AspNetCore.Mvc;

namespace Ascend.AuthService.Domain.Contracts;

public class CustomProblemDetails : ProblemDetails
{
    public IEnumerable<object> Errors { get; set; }
}