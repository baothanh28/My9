using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Todo.Domain.Events;

namespace FSH.Starter.WebApi.Todo.Domain;
public class DemoItem : AuditableEntity, IAggregateRoot
{
    public string? Title { get; set; }

    public string? Note { get; set; }

    public static DemoItem Create(string title, string note)
    {
        var item = new DemoItem();

        item.Title = title;
        item.Note = note;

        item.QueueDomainEvent(new DemoItemCreated(item.Id, item.Title, item.Note));

        DemoMetrics.Created.Add(1);

        return item;
    }

    public DemoItem Update(string? title, string? note)
    {
        if (title is not null && Title?.Equals(title, StringComparison.OrdinalIgnoreCase) is not true) Title = title;
        if (note is not null && Note?.Equals(note, StringComparison.OrdinalIgnoreCase) is not true) Note = note;

        this.QueueDomainEvent(new DemoItemUpdated(this));

        return this;

    }
}
