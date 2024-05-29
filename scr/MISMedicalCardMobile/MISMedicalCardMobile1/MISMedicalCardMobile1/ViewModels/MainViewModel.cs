using Avalonia.Notification;
using MISMedicalCardMobile1.Service;
using ReactiveUI;

namespace MISMedicalCardMobile1.ViewModels;

public class MainViewModel : ViewModelBase
{
    public INotificationMessageManager Manager { get; }
    private ViewModelBase _selectedViewModel;
    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }
    
    public MainViewModel(ITypeMedicalEventRepository typeMedicalEventRepository, IGenderRepository genderRepository, 
        IInsuranceCompanyRepository insuranceCompanyRepository, IMedicalCardRepository medicalCardRepository, INotificationService notificationService,
        ISoundService soundService, ISoundMessageRepository soundMessageRepository)
    {
        SelectedViewModel = new AuthorizationViewModel(typeMedicalEventRepository, genderRepository, insuranceCompanyRepository, 
            medicalCardRepository, notificationService, soundService, soundMessageRepository) { Owner = this };
    }
}