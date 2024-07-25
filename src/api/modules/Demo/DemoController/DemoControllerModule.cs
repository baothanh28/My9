using Carter;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace DemoController
{
    public static class DemoControllerModule
    {

        //public class Endpoints : CarterModule
        //{
        //    public override void AddRoutes(IEndpointRouteBuilder app)
        //    {
        //        var demoGroup = app.MapGroup("demos").WithTags("demos");
        //    }
        //}
        public static WebApplicationBuilder RegisterDemoControllerServices(this WebApplicationBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);
            builder.Services.AddControllers();

            return builder;
        }
        public static WebApplication UseDemoControllerModule(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }

}


