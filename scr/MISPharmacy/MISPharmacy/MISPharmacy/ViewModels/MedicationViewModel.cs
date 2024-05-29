using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using MISPharmacy.Models;
using MISPharmacy.Service;
using MISPharmacy.ViewModels;
using ReactiveUI;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace MISPharmacy.Views;

public class MedicationViewModel : ViewModelBase
{
    private INotificationService _notificationService;
    public List<Medication> Medications { get; set; }
    public List<Storage> Storages { get; set; }
    public Storage SelectedStorages { get; set; }
    
    public ReactiveCommand<Unit, Unit> GetMedicationCommand { get; }
    public ReactiveCommand<Medication, Unit> DetailsMedicationCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToReviewViewCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToOrderViewCommand { get; }
    public MedicationViewModel(IDepartamentRepository departamentRepository, IStorageRepository storageRepository, IOrderRepository orderRepository, 
        IDistributionRepository distributionRepository, IMedicationRepository medicationRepository, IPartyRepository partyRepository, 
        INotificationService notificationService, ISupplierRepository supplierRepository)
    {
        GetMedicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var responce = medicationRepository.GetMedication();
            if (responce == null)
                notificationService.Show(new Notification("Ошибка подключения", "Отсутствует соединение с сервером"));
            Medications = responce.Result;
        });
        GetMedicationCommand.Execute().Subscribe();
        
        GoToReviewViewCommand = ReactiveCommand.Create( () =>
        {
            (Owner as MainViewModel).SelectedViewModel = new ReviewViewModel(medicationRepository, notificationService) { Owner = this };
        });
        
        GoToOrderViewCommand = ReactiveCommand.Create( () =>
        {
            (Owner as MainViewModel).SelectedViewModel = new ReviewViewModel(medicationRepository, notificationService) { Owner = this };
        });

        DetailsMedicationCommand = ReactiveCommand.Create<Medication>(DetailsMedication);
    }

    private void DetailsMedication(Medication medication)
    {
        (Owner as MainViewModel).SelectedViewModel = new DetailMedicationViewModel(medication, _notificationService) { Owner = this };
    }
}