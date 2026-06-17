using Ascend.Auth.Business.Abstractions;
using Ascend.Auth.DataAccess;
using MediatR;

namespace Ascend.Auth.Presentation.REST.Behaviors;

public class TransactionBehavior<TRequest, TResponse>(
    AscendAuthDbContext context,
    ILogger<TransactionBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(ct);
        try
        {
            var response = await next();
            await context.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Transaction failed for {Request}", typeof(TRequest).Name);
            await transaction.RollbackAsync(ct);
            throw;
        }
    }
}
