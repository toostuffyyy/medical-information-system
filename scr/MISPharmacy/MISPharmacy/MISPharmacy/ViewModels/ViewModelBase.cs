using ReactiveUI;

namespace MISPharmacy.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}