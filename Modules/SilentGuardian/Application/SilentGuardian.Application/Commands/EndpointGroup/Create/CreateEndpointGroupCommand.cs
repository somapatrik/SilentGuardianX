using Mediator;

namespace SilentGuardian.Application.Commands.EndpointGroup.Create;

public class CreateEndpointGroupCommand : ICommand
{
    public string GroupName { get; }
    public string? Description { get; }

    public CreateEndpointGroupCommand(string groupName, string? description = null)
    {
        GroupName = groupName;
        Description = description;
    }
}