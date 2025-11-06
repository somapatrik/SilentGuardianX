using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Domain.Repositories;

public interface IEndpointGroupRepository
{
    Task CreateAsync(EndpointGroup endpointGroup);
    Task<IEnumerable<EndpointGroup>> GetAsync();
}