using FluentValidation;
using FSH.Starter.WebApi.Todo.Persistence;

namespace FSH.Starter.WebApi.Todo.Features.Create.v1;
public class CreateDemoValidator : AbstractValidator<CreateDemoCommand>
{
    public CreateDemoValidator(DemoDbContext context)
    {
        RuleFor(p => p.Title).NotEmpty();
        RuleFor(p => p.Note).NotEmpty();
    }
}
