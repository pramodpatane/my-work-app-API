using Server.Domain.Entities.Core;
using Server.Infrastructure.Contexts;

public class RequestCounterMiddleware
{
    private readonly RequestDelegate _next;

    public RequestCounterMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, MyContext dbContext)
    {
        try
        {
            // Before request → save log
            var counter = new RequestCounter
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                RequestedAt = DateTime.Now
            };

            dbContext.RequestCounters.Add(counter);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Optional: Log error, don't stop API
            throw ex;
        }

        // Continue pipeline
        await _next(context);
    }
}
