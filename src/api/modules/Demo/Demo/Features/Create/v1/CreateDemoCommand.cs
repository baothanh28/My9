using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Todo.Features.Create.v1;
public record CreateDemoCommand(
    [property: DefaultValue("Hello World!")] string Title,
    [property: DefaultValue("Important Note.")] string Note) : IRequest<CreateDemoResponse>;



