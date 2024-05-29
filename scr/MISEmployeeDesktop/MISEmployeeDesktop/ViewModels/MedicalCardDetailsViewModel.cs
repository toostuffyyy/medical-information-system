using System.Collections.Generic;
using System.Linq;
using MISEmployeeDesktop.Context;
using MISEmployeeDesktop.Entities;
using MISEmployeeDesktop.ViewModels;

namespace MISEmployeeDesktop.Views;

public class MedicalCardDetailsViewModel : ViewModelBase
{
    public MedicalCard MedicalCard { get; set; }
    public Patient Patient { get; set; }
    public InsurancePolicy InsurancePolicy { get; set; }
    public List<InsuranceCompany> InsuranceCompanies { get; set; }
    public List<Gender> Genders { get; set; }
    public MedicalCardDetailsViewModel(MedicalCard medicalCard)
    {
        MedicalCard = medicalCard;
        Patient = medicalCard.Patient;
        InsurancePolicy = medicalCard.Patient.InsurancePolicies.ToList()[0];
        InsuranceCompanies = DataBaseContext.Context().InsuranceCompanies.ToList();
        Genders = DataBaseContext.Context().Genders.ToList();
    }
    /// <summary>
    /// Перейти на форму с созданием направления.
    /// </summary>
    public void GoCreateMedicalEvent()
    {
        (Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = new CreateMedicalEventViewModel(MedicalCard) { Owner = this };
    }
    /// <summary>
    /// Команда для выхода к таблице с мед. картами. 
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
}