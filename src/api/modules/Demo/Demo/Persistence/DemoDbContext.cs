using Finbuckle.MultiTenant.Abstractions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Framework.Infrastructure.Tenant;
using FSH.Starter.WebApi.Todo.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.Starter.WebApi.Todo.Persistence;
public sealed class DemoDbContext: FshSingleDbContext
{
    public DemoDbContext(DbContextOptions options,
    IPublisher publisher,
    IOptions<DatabaseOptions> settings):base(options, publisher, settings)  
    {
    }

    public DbSet<DemoItem> Demos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoDbContext).Assembly);
        modelBuilder.HasDefaultSchema("Demo");
    }
}
