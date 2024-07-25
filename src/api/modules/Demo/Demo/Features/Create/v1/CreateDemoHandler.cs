using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Todo.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Todo.Features.Create.v1;
public sealed class CreateDemoHandler(
    ILogger<CreateDemoHandler> logger,
    [FromKeyedServices("demo")] IRepository<DemoItem> repository)
    : IRequestHandler<CreateDemoCommand, CreateDemoResponse>
{
    public async Task<CreateDemoResponse> Handle(CreateDemoCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = DemoItem.Create(request.Title, request.Note);
        await repository.AddAsync(item, cancellationToken).ConfigureAwait(false);
        await repository.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        logger.LogInformation("demo item created {TodoItemId}", item.Id);
        return new CreateDemoResponse(item.Id);
    }
}
