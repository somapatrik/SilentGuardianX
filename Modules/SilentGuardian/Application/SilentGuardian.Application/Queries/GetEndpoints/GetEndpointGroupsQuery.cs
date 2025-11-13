using Mediator;
using SilentGuardian.Application.DTOs.Endpoints;

namespace SilentGuardian.Application.Queries.GetEndpoints;

public class GetEndpointGroupsQuery : IQuery<IEnumerable<EndpointGroupDTO>>
{
    public GetEndpointGroupsQuery()
    {
    }
}