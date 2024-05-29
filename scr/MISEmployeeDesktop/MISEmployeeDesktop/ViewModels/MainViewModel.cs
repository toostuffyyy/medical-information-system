using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using MISEmployeeDesktop.Context;
using MISEmployeeDesktop.Entities;
using MISEmployeeDesktop.Views;
using ReactiveUI;

namespace MISEmployeeDesktop.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IPersonalLocationRepository _personLocationsRepoitory;
    public List<MedicalCard> MedicalCards { get; set; }
    public ReactiveCommand<MedicalCard, Unit> DetailedCommand { get; private set; }
    public MainViewModel(IPersonalLocationRepository personalLocationRepository)
    {
        _personLocationsRepoitory = personalLocationRepository;
        MedicalCards = DataBaseContext.Context().MedicalCards
            .Include(a => a.Patient)
            .ThenInclude(a => a.InsurancePolicies)
            .ToList();
        DetailedCommand = ReactiveCommand.Create<MedicalCard>(Detailed);
    }

    private void Detailed(MedicalCard medicalCard)
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = new MedicalCardDetailsViewModel(medicalCard){ Owner = this };
    }

    public void GoBack()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
    /// <summary>
    /// Переход на форму для отслеживания.
    /// </summary>
    public void GoTrackingView()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = new TrackingViewModel(_personLocationsRepoitory) {Owner = this};
    }
}