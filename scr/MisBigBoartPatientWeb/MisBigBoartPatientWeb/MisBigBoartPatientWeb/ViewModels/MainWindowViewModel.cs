using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using ReactiveUI;

namespace MisBigBoartPatientWeb.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _selectedView;

    public ViewModelBase SelectedView
    {
        get => _selectedView;
        set => this.RaiseAndSetIfChanged(ref _selectedView, value);
    }
    public MainWindowViewModel()
    {
        SelectedView = new AuthorizarionViewModel(){Owner = this};
    }
}