using SilentGuardian.Domain.Repositories;

namespace SilentGuardianX.ViewModels;

public class MainViewModel(IEndpointGroupRepository endpointGroupRepository) : ViewModelBase
{
    private readonly IEndpointGroupRepository _endpointGroupRepository = endpointGroupRepository;
}