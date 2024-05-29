using ReactiveUI;

namespace MISMedicalCardMobile1.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public ViewModelBase Owner { get; set; }
}