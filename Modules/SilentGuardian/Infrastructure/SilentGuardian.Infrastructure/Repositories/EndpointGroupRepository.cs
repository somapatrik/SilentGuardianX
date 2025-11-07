using SilentGuardian.Domain.Endpoints;
using SilentGuardian.Domain.Repositories;
using SilentGuardian.Infrastructure.Context;

namespace SilentGuardian.Infrastructure.Repositories;

public class EndpointGroupRepository : IEndpointGroupRepository
{
    private SilentGuardianContext _context;

    public EndpointGroupRepository(SilentGuardianContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(EndpointGroup endpointGroup)
    {
        await _context.EndpointGroups.AddAsync(endpointGroup);
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<EndpointGroup>> GetAsync()
    {
        throw new NotImplementedException();
    }
}