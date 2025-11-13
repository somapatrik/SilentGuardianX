using Mediator;
using SilentGuardian.Application.DTOs.Endpoints;
using SilentGuardian.Domain.Repositories;

namespace SilentGuardian.Application.Queries.GetEndpoints;

public class GetEndpointGroupsQueryHandler : IQueryHandler<GetEndpointGroupsQuery, IEnumerable<EndpointGroupDTO>>
{
    private readonly IEndpointGroupRepository _endpointGroupRepository;

    public GetEndpointGroupsQueryHandler(IEndpointGroupRepository  endpointGroupRepository)
    {
        _endpointGroupRepository = endpointGroupRepository;
    }

    public async ValueTask<IEnumerable<EndpointGroupDTO>> Handle(GetEndpointGroupsQuery query, CancellationToken cancellationToken)
    {
        var groups = await _endpointGroupRepository.GetAsync();
        var dtos = groups.Select(g => new EndpointGroupDTO()
        {
          Id = g.Id,
          
        })};
    }
}