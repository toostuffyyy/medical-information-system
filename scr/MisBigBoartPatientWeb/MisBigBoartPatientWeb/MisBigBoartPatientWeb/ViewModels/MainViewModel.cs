using Avalonia.Animation;
using Avalonia.Controls.Primitives;
using MisBigBoartPatientWeb.ViewModels;
using ReactiveUI;

namespace MisBigBoartPatientWeb.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }

    public MainViewModel()
    {
        SelectedViewModel = new AuthorizarionViewModel() { Owner = this };
    }
}