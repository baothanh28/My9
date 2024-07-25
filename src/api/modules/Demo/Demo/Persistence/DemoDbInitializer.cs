using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Todo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Todo.Persistence;
internal sealed class DemoDbInitializer(
    ILogger<DemoDbInitializer> logger,
    DemoDbContext context) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        if ((await context.Database.GetPendingMigrationsAsync(cancellationToken).ConfigureAwait(false)).Any())
        {
            await context.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("applied database migrations for demo module");
        }
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        const string Title = "Hello World!";
        const string Note = "This is your first task";
        if (await context.Demos.FirstOrDefaultAsync(t => t.Title == Title, cancellationToken).ConfigureAwait(false) is null)
        {
            var todo = DemoItem.Create(Title, Note);
            await context.Demos.AddAsync(todo, cancellationToken);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            logger.LogInformation("seeding default demo data");
        }
    }
}
