using System.Linq;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using MisBigBoartPatientWeb.Context;
using MisBigBoartPatientWeb.Entities;
using MisBigBoartPatientWeb.Views;
using ReactiveUI;

namespace MisBigBoartPatientWeb.ViewModels;

public class AuthorizarionViewModel : ViewModelBase
{
    public Hospitalization Hospitalization { get; set; }
    public AuthorizarionViewModel()
    {
        Hospitalization = new Hospitalization();
    }
    /// <summary>
    /// Переход на форму с госпитализацией по коду.
    /// </summary>
    public void GoToHospitalization()
    {
        var hospitalization = DataBaseContext.Context().Hospitalizations
            .Include(a => a.MedicalEvent)
            .ThenInclude(a => a.MedicalCardNumberNavigation)
            .ThenInclude(a => a.Patient)
            .ThenInclude(a => a.InsurancePolicies)
            .FirstOrDefault(a => a.Code == Hospitalization.Code);
        if (hospitalization != null)
            (Owner as MainViewModel).SelectedViewModel = new HospitalizationViewModel(hospitalization) { Owner = this };
        else
            return;//Уведомление;
        
    }
    /// <summary>
    /// Считывание qr кода.
    /// </summary>
    public void GoToWriteQRCode()
    {
        
    }
    /// <summary>
    /// Переход на форму регистрации.
    /// </summary>
    public void GoToRegistration()
    {
        (Owner as MainViewModel).SelectedViewModel = new RegistrationViewModel() {Owner = this};
    }
}