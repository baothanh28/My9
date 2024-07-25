using System.Diagnostics.Metrics;
using FSH.Starter.Aspire.ServiceDefaults;

namespace FSH.Starter.WebApi.Todo.Domain;

public static class DemoMetrics
{
    private static readonly Meter Meter = new Meter("Demo", "1.0.0");
    public static readonly Counter<int> Created = Meter.CreateCounter<int>("items.created");
    public static readonly Counter<int> Updated = Meter.CreateCounter<int>("items.updated");
    public static readonly Counter<int> Deleted = Meter.CreateCounter<int>("items.deleted");
}

