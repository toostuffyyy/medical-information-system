using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AvaloniaApplication3.Services;
using ReactiveUI;
using Refit;

namespace AvaloniaApplication3.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ISoundService _soundService;
    private readonly ISoundMessageRepository _soundMessageRepository;
    private bool _isRecord;
    private int _second;
    private int minute;
    private Timer _timer; 
    private string _time;
    
    public MainViewModel(ISoundService soundService,ISoundMessageRepository soundMessageRepository)
    {
        _soundService = soundService;
        _soundMessageRepository = soundMessageRepository;
        StartRecordCommand = ReactiveCommand.CreateFromObservable(StartRecord);
        StopRecordCommand = ReactiveCommand.CreateFromTask(StopRecord);
    }
    public ReactiveCommand<Unit,Unit> StartRecordCommand { get; }
    public ReactiveCommand<Unit,Unit> StopRecordCommand { get; }
    
    public bool IsRecord
    {
        get => _isRecord;
        set => this.RaiseAndSetIfChanged(ref _isRecord, value);
    }

    public string Time
    {
        get => _time;
        set => this.RaiseAndSetIfChanged(ref _time, value);
    }
    private IObservable<Unit> StartRecord()
    {
        return Observable.Start(() =>
        {
            IsRecord = true;
            _soundService.StartRecord("soundMessage.3gp");
            _timer = new Timer(new TimerCallback(CountTime), 0, 0, 1000); 
        });
    }

    private void CountTime(object obj)
    {
        _second++;
        Time = TimeSpan.FromSeconds(_second).ToString(@"mm\:ss");
    }
    private async Task StopRecord()
    {
        _timer.Dispose();
        await using var stream = _soundService.StopRecord();
        StreamPart streamPart = new StreamPart(stream,"soundMessage.3gp","video/ogp");
        await _soundMessageRepository.AddSoundMessage(streamPart);
        IsRecord = false;
        _second = 0;
    }
}