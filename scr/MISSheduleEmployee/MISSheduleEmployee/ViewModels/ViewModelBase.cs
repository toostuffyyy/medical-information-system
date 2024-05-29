using ReactiveUI;

namespace MISSheduleEmployee.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}