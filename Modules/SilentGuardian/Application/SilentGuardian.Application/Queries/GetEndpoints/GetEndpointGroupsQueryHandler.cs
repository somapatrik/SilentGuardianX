using Mediator;
using SilentGuardian.Application.DTOs.Endpoints;
using SilentGuardian.Application.Mappers.Interfaces;
using SilentGuardian.Domain.Repositories;

namespace SilentGuardian.Application.Queries.GetEndpoints;

public class GetEndpointGroupsQueryHandler : IQueryHandler<GetEndpointGroupsQuery, IEnumerable<EndpointGroupDTO>>
{
    private readonly IEndpointGroupRepository _endpointGroupRepository;
    private readonly IAppMapper _mapper;

    public GetEndpointGroupsQueryHandler(IEndpointGroupRepository  endpointGroupRepository, IAppMapper mapper)
    {
        _endpointGroupRepository = endpointGroupRepository;
        _mapper = mapper;
    }

    public async ValueTask<IEnumerable<EndpointGroupDTO>> Handle(GetEndpointGroupsQuery query, CancellationToken cancellationToken)
    {
        var groups = await _endpointGroupRepository.GetAsync();
        var groupDTOs = groups.Select(_mapper.ToDTO).ToList();
        return groupDTOs;
    }
}