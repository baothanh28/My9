
using FSH.Framework.Core.Caching;
using FSH.Framework.Core.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Todo.Domain.Events;
public record DemoItemCreated(Guid Id, string Title, string Notes) : DomainEvent;

public class TodoItemCreatedEventHandler(
    ILogger<TodoItemCreatedEventHandler> logger,
    ICacheService cache)
    : INotificationHandler<DemoItemCreated>
{
    public async Task Handle(DemoItemCreated notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("handling todo item created domain event..");
    }
}
