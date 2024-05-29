using ReactiveUI;

namespace MISEmployeeDesktop.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}