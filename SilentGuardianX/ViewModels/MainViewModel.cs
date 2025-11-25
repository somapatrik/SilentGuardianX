using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Mediator;
using SilentGuardian.Application.Commands.EndpointGroup.Create;
using SilentGuardian.Application.Queries.GetEndpoints;
using SilentGuardian.Domain.Repositories;
using SilentGuardianX.ViewModels.Components;

namespace SilentGuardianX.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MenuViewModel MenuViewModel { get; }
    
    IMediator _mediator;
    
    public MainViewModel(IMediator mediator, MenuViewModel menuViewModel)
    {
        MenuViewModel = menuViewModel;
        _mediator = mediator;
    }
}