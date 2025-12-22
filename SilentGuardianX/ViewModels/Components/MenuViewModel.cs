using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mediator;
using SilentGuardian.Application.Commands.EndpointGroup.Create;
using SilentGuardian.Application.DTOs.Endpoints;
using SilentGuardian.Application.Queries.GetEndpoints;

namespace SilentGuardianX.ViewModels.Components;

public partial class MenuViewModel : ViewModelBase
{
    private readonly IMediator _mediator;
    [ObservableProperty] private bool _displayGroupCreation;
    [ObservableProperty] private string _groupName;
    [ObservableProperty] private string _description;

    [ObservableProperty]
    private ObservableCollection<EndpointGroupDTO> _endpointGroups = new();

    public MenuViewModel(IMediator mediator)
    {
        _mediator = mediator;
        
        _ = LoadGroups();
    }

    [RelayCommand]
    private void ToggleGroupCreation()
    {
        DisplayGroupCreation = !DisplayGroupCreation;
    }

    [RelayCommand]
    private async Task CreateGroup()
    {
        await _mediator.Send(new CreateEndpointGroupCommand(GroupName, Description));
        await LoadGroups();
        DisplayGroupCreation = false;
    }

    private async Task LoadGroups()
    { 
        EndpointGroups = new ObservableCollection<EndpointGroupDTO>();
        foreach (var group in await _mediator.Send(new GetEndpointGroupsQuery())) 
            EndpointGroups.Add(group);
    }

}