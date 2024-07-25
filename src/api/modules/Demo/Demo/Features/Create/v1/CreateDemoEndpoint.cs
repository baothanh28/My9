using Asp.Versioning;
using FSH.Framework.Infrastructure.Auth.Policy;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Todo.Features.Create.v1;
public static class CreateDemoEndpoint
{
    internal static RouteHandlerBuilder MapDemoItemCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", async (CreateDemoCommand request, ISender mediator) =>
                {
                    var response = await mediator.Send(request);
                    return Results.CreatedAtRoute(nameof(CreateDemoEndpoint), new { id = response.Id }, response);
                })
                .WithName(nameof(CreateDemoEndpoint))
                .WithSummary("Creates a demo item")
                .WithDescription("Creates a demo item")
                .Produces<CreateDemoResponse>(StatusCodes.Status201Created)
                .AllowAnonymous()
                //.RequirePermission("Permissions.Todos.Create")
                .MapToApiVersion(new ApiVersion(1, 0));

    }
}
