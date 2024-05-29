using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using MISPharmacy.Models;
using MISPharmacy.Service;
using ReactiveUI;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace MISPharmacy.ViewModels;

public class ReviewViewModel : ViewModelBase
{
    public List<Medication> Medications { get; set; }
    public ReactiveCommand<Unit, Unit> GetMedicationCommand { get; }
    public ReactiveCommand<Unit, Unit> GoBackCommand { get; }
    public ReviewViewModel(IMedicationRepository medicationRepository, INotificationService notificationService)
    {
        GetMedicationCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var responce = medicationRepository.GetMedication();
            if (responce == null)
                notificationService.Show(new Notification("Ошибка подключения", "Отсутствует соединение с сервером"));
            Medications = responce.Result;
        });
        GetMedicationCommand.Execute().Subscribe();
        
        GoBackCommand = ReactiveCommand.Create(() =>
        {
            (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
        });
        Medications = Medications.Where(a => a.SumAmount < 200).ToList();
    }
}