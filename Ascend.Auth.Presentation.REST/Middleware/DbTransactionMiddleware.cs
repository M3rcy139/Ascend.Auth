using Ascend.Auth.DataAccess;

namespace Ascend.Auth.Presentation.REST.Middleware;

public class DbTransactionMiddleware
{
    private readonly RequestDelegate _next;

    public DbTransactionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AscendAuthDbContext dbContext)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            await _next(context);

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}