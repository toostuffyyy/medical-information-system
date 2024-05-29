using MISPharmacy.Service;
using MISPharmacy.Views;
using ReactiveUI;

namespace MISPharmacy.ViewModels;

public class MainViewModel : ViewModelBase
{
    private ViewModelBase _selectedViewModel;

    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => this.RaiseAndSetIfChanged(ref _selectedViewModel, value);
    }

    public MainViewModel(IDepartamentRepository departamentRepository, IStorageRepository storageRepository, IOrderRepository orderRepository, 
        IDistributionRepository distributionRepository, IMedicationRepository medicationRepository, IPartyRepository partyRepository, 
        INotificationService notificationService, ISupplierRepository supplierRepository)
    {
        SelectedViewModel = new MedicationViewModel(departamentRepository, storageRepository, orderRepository, distributionRepository, medicationRepository,
            partyRepository, notificationService, supplierRepository) { Owner = this };
    }
}