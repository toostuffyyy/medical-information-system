using ReactiveUI;

namespace MISSheduleEmployee.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }
    /// <summary>
    /// Конструктор MainWindowViewModel.
    /// </summary>
    public MainWindowViewModel()
    {
        SelectedViewModel = new AuthorizationViewModel() { Owner = this };
    }
}