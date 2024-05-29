using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using MISMedicalCardMobile1.Models;
using MISMedicalCardMobile1.Service;
using ReactiveUI;
using Refit;

namespace MISMedicalCardMobile1.ViewModels;

public class MedicalCardViewModel : ViewModelBase
{
    private readonly ITypeMedicalEventRepository _typeMedicalEventRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
    private readonly IMedicalCardRepository _medicalCardRepository;
    private readonly INotificationService _notificationService;
    private readonly ISoundService _soundService;
    private readonly ISoundMessageRepository _soundMessageRepository;

    private bool _isRecond;
    private int _second;
    private int _minute;
    private string _time;
    private Timer _timer;

    public bool IsRecond
    {
        get => _isRecond;
        set => this.RaiseAndSetIfChanged(ref _isRecond, value);
    }
    
    public string Time
    {
        get => _time;
        set => this.RaiseAndSetIfChanged(ref _time, value);
    }
    public MedicalCard MedicalCard { get; set; }
    public ReactiveCommand<Unit, Unit> StartRecordCommand { get; }
    public ReactiveCommand<Unit, Unit> StopRecordCommand { get; }
    public MedicalCardViewModel(int number, ITypeMedicalEventRepository typeMedicalEventRepository, IGenderRepository genderRepository, 
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

        
        StartRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            IsRecond = true;
            _soundService.StartRecord("soundMessage.3gp");
            _timer = new Timer(TimerCallBack, 0, 0, 1000);
        });
        
        StopRecordCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            _timer.Dispose();
            await using var stream = _soundService.StopRecord();
            var streamPart = new StreamPart(stream, "soundMessage.3gp", "video/3gpp");
            IsRecond = false;
            _second = 0;
            await _soundMessageRepository.AddSoundMessage(streamPart);
        });
        StopRecordCommand.ThrownExceptions.Subscribe(e => Console.Write(e));
    }

    private void TimerCallBack(object? state)
    {
        _second++;
        Time = TimeSpan.FromSeconds(_second).ToString(@"mm\:ss");
    }
}