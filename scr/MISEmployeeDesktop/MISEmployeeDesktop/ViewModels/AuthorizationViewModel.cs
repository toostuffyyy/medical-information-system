using System.Linq;
using MISEmployeeDesktop.Context;
using MISEmployeeDesktop.Entities;

namespace MISEmployeeDesktop.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    private readonly IPersonalLocationRepository _personalLocationRepository;

    public Doctor Doctor { get; set; }
    public AuthorizationViewModel(IPersonalLocationRepository personalLocationRepository)
    {
        _personalLocationRepository = personalLocationRepository;
        Doctor = new Doctor();
    }
    /// <summary>
    /// Авторизация по уникальному значению.
    /// </summary>
    public void Authorization()
    {
        var doctor = DataBaseContext.Context().Doctors.FirstOrDefault(a => a.Id == Doctor.Id);
        if (doctor != null)
        {
            DoctorId.Id = doctor.Id;
            (Owner as MainWindowViewModel).SelectedViewModel = new MainViewModel(_personalLocationRepository) {Owner = this};
        }
        else
            return; //Уведомление.
    }
}