using ReactiveUI;

namespace MISEmployeeDesktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }

    public MainWindowViewModel(IPersonalLocationRepository personalLocationRepository)
    {
        SelectedViewModel = new AuthorizationViewModel(personalLocationRepository) { Owner = this };
    }
}