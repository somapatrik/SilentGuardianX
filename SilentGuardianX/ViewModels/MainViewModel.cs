using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Mediator;
using SilentGuardian.Application.Commands.EndpointGroup.Create;
using SilentGuardian.Domain.Repositories;

namespace SilentGuardianX.ViewModels;

public class MainViewModel : ViewModelBase
{
    IMediator _mediator;
    public MainViewModel(IMediator mediator)
    {
        _mediator = mediator;

        CreateGroup();
    }
    
    private async void CreateGroup()
    {
        await _mediator.Send(new CreateEndpointGroupCommand("Test", "dhsfjkhdsf"));    
    }
}