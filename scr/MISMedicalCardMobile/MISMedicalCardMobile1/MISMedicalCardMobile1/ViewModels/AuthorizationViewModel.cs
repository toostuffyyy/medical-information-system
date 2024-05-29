using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using MISMedicalCardMobile1.Models;
using MISMedicalCardMobile1.Service;
using ReactiveUI;
using Splat;
using Notification = Avalonia.Controls.Notifications.Notification;

namespace MISMedicalCardMobile1.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    private readonly ITypeMedicalEventRepository _typeMedicalEventRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
    private readonly IMedicalCardRepository _medicalCardRepository;
    private readonly INotificationService _notificationService;
    private readonly ISoundService _soundService;
    private readonly ISoundMessageRepository _soundMessageRepository;
    public MedicalCard MedicalCard { get; set; }
    
    public ReactiveCommand<Unit, Task> GetMedicalCardCommand { get; }
    public AuthorizationViewModel(ITypeMedicalEventRepository typeMedicalEventRepository, IGenderRepository genderRepository, 
        IInsuranceCompanyRepository insuranceCompanyRepository, IMedicalCardRepository medicalCardRepository, INotificationService notificationService,
        ISoundService soundService, ISoundMessageRepository soundMessageRepository)
    {
        _typeMedicalEventRepository = typeMedicalEventRepository;
        _genderRepository = genderRepository;
        _insuranceCompanyRepository = insuranceCompanyRepository;
        _medicalCardRepository = medicalCardRepository;
        _notificationService = notificationService;
        _soundService = soundService;
        _soundMessageRepository = soundMessageRepository;

        MedicalCard = new MedicalCard();
        
        GetMedicalCardCommand = ReactiveCommand.Create(async () =>
        {
            var responce = _medicalCardRepository.GetMedicalCart(MedicalCard.Number);
            if (responce != null)
                MedicalCard.LastVisitDate = responce.Result.LastVisitDate;
            return;
        });
        GetMedicalCardCommand.ThrownExceptions.Subscribe(e => Console.Write(e));
    }
}