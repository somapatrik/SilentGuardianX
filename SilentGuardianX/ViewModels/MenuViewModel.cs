using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SilentGuardianX.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    [ObservableProperty] private bool _displayGroupCreation;

    [RelayCommand]
    private void ToggleGroupCreation()
    {
        DisplayGroupCreation = !DisplayGroupCreation;
    }

}