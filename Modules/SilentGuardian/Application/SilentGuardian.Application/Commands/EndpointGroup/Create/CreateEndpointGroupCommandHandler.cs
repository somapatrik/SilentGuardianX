using Mediator;
using SilentGuardian.Domain.Repositories;

namespace SilentGuardian.Application.Commands.EndpointGroup.Create;

public class CreateEndpointGroupCommandHandler : ICommandHandler<CreateEndpointGroupCommand>
{
    private readonly IEndpointGroupRepository _repository;

    public CreateEndpointGroupCommandHandler(IEndpointGroupRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<Unit> Handle(CreateEndpointGroupCommand command, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(Domain.Endpoints.EndpointGroup.Create(command.GroupName,command.Description));
        return Unit.Value;
    }
}