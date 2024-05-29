using ReactiveUI;

namespace MisBigBoartPatientWeb.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}