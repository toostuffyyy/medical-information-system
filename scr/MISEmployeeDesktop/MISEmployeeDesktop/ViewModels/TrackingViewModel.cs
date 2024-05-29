using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using MISEmployeeDesktop.Models;
using ReactiveUI;

namespace MISEmployeeDesktop.ViewModels;

public class TrackingViewModel : ViewModelBase
{
    private readonly IPersonalLocationRepository _personalLocationRepository;
    private readonly Timer _timer;
    private readonly Random _random;
    
    public List<Cabinet> Cabinets { get; set; }
    
    private ObservableAsPropertyHelper<IEnumerable<PersonalLocation>> _personalLocation;
    public IEnumerable<PersonalLocation> PersonalLocations => _personalLocation.Value;
    
    public ReactiveCommand<Unit,ResponceRersonalLocation> GetPersonalLocationCommand { get; } 
    public TrackingViewModel(IPersonalLocationRepository personalLocationRepository)
    {
        _personalLocationRepository = personalLocationRepository;
        _random = new Random();
        Cabinets = new List<Cabinet>
        {
            // Middle.
            new(){Skud = -2, Title = "", X = -3, Width = 1610, Y = new Cabinet().Height },
            // Top.
            new(){Skud = 17, Title = "Стерилизационная", X = 0, Width = 73 },
            new(){Skud = 18, Title = "Архив", X = 70, Width = 73 },
            new(){Skud = 19, Title = "Главный врач", X = 140, Width = 143 },
            new(){Skud = 20, Title = "Комната приема пищи", X = 280, Width = 73 },
            new(){Skud = 21, Title = "Терапевтический кабинет", X = 350, Width = 213 },
            new(){Skud = 22, Title = "Санитарная комната", X = 560, Width = 73 },
            new(){Skud = -1, Title = "Общий туалет", X = 630, Width = 73 },
            new(){Skud = 0, Title = "", X = 700, Width = 213 },
            new(){Skud = 1, Title = "Регистратура", X = 910, Width = 143 },
            new(){Skud = 2, Title = "Комната утил.мед.отходов", X = 1050, Width = 73 },
            new(){Skud = 3, Title = "Служебный туалет", X = 1120, Width = 73 },
            new(){Skud = 4, Title = "Заведуюшие отделением", X = 1190, Width = 143 },
            new(){Skud = 5, Title = "Главная медицинская сестра", X = 1330, Width = 143 },
            new(){Skud = 6, Title = "Кабинет гигены полости рта", X = 1470, Width = 143 },
            // Bottom.
            new(){Skud = 16, Title = "Заведующая хозяйством Специалист ОТ", X = 0, Width = 143, Y = new Cabinet().Height * 2 },
            new(){Skud = 15, Title = "Стоматологический кабинет", X = 140, Width = 213, Y = new Cabinet().Height * 2 },
            new(){Skud = 14, Title = "Физико-терапевтический кабинет", X = 350, Width = 253, Y = new Cabinet().Height * 2 },
            new(){Skud = 13, Title = "Экономисты", X = 600, Width = 73, Y = new Cabinet().Height * 2 },
            new(){Skud = 12, Title = "Хирургический кабинет", X = 670, Width = 213, Y = new Cabinet().Height * 2 },
            new(){Skud = 11, Title = "Бухгалтерия", X = 880, Width = 123, Y = new Cabinet().Height * 2 },
            new(){Skud = 10, Title = "Гардеробная персонала", X = 1000, Width = 73, Y = new Cabinet().Height * 2 },
            new(){Skud = 9, Title = "Компьютерная", X = 1070, Width = 123, Y = new Cabinet().Height * 2 },
            new(){Skud = 8, Title = "Терапевтический кабинет", X = 1190, Width = 213, Y = new Cabinet().Height * 2 },
            new(){Skud = 7, Title = "Терапевтический кабинет", X = 1400, Width = 213, Y = new Cabinet().Height * 2 }
        };
        GetPersonalLocationCommand = ReactiveCommand.CreateFromTask(GetPersonalLocation);
        _personalLocation = GetPersonalLocationCommand.Select(a => a.Responce).ToProperty(this, a => a.PersonalLocations);
        _timer = new Timer(TimerCallBack, null, 0, 3000);
    }
    private void TimerCallBack(object? state)
    {
        GetPersonalLocationCommand.Execute().Subscribe();
    }
    /// <summary>
    /// Задача для получения и обработки данных с API.
    /// </summary>
    /// <returns>responce, возвращает обработанный список с локациями.</returns>
    private async Task<ResponceRersonalLocation> GetPersonalLocation()
    {
        var responce = await _personalLocationRepository.GetPersonalLocation();
        int slep = 30;
        foreach (var person in responce.Responce)
        {
            var cab = person.LastSecurityPointDirection == "in"
                ? Cabinets.FirstOrDefault(a => a.Skud == person.LastSecurityPointNumber)
                : Cabinets[0];
            person.X = _random.Next((int)cab.X + slep, (int)(cab.X + cab.Width) - slep);
            person.Y = _random.Next((int)cab.Y + slep, (int)(cab.Y + cab.Height) - slep);
        }
        return responce;
    }
    /// <summary>
    /// Выход на форму с пациентами.
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
}