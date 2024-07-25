using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using FSH.Starter.WebApi.Todo.Domain;
using FSH.Starter.WebApi.Todo.Features.Create.v1;
using FSH.Starter.WebApi.Todo.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Todo;
public static class DemoModule
{

    public class Endpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var demoGroup = app.MapGroup("demos").WithTags("demos");
            demoGroup.MapDemoItemCreationEndpoint();
        }
    }
    public static WebApplicationBuilder RegisterDemoServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Services.BindDbContext<DemoDbContext>();
        builder.Services.AddScoped<IDbInitializer, DemoDbInitializer>();
        builder.Services.AddKeyedScoped<IRepository<DemoItem>, DemoRepository<DemoItem>>("demo");
        builder.Services.AddKeyedScoped<IReadRepository<DemoItem>, DemoRepository<DemoItem>>("demo");
        return builder;
    }
    public static WebApplication UseDemoModule(this WebApplication app)
    {
        return app;
    }
}
