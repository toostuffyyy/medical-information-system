using System;
using System.Collections.Generic;
using System.Linq;
using MisBigBoartPatientWeb.Context;
using MisBigBoartPatientWeb.Entities;

namespace MisBigBoartPatientWeb.ViewModels;

public class HospitalizationViewModel : ViewModelBase
{
    public Hospitalization Hospitalization { get; set; }
    public List<InsuranceCompany> InsuranceCompanies { get; set; }
    public List<StatusHospitalization> StatusHospitalizations { get; set; }
    public List<Department> Departments { get; set; }
    public List<TypeHospitalization> TypeHospitalizations { get; set; }
    public List<Gender> Genders { get; set; }
    public Patient Patient { get; set; }
    public InsurancePolicy InsurancePolicy { get; set; }
    public HospitalizationViewModel(Hospitalization hospitalization)
    {
        try
        {
            Hospitalization = hospitalization;
            Patient = hospitalization.MedicalEvent.MedicalCardNumberNavigation.Patient;
            InsurancePolicy = Patient.InsurancePolicies.ToList()[0];
            InsuranceCompanies = DataBaseContext.Context().InsuranceCompanies.ToList();
            Genders = DataBaseContext.Context().Genders.ToList();
            StatusHospitalizations = DataBaseContext.Context().StatusHospitalizations.ToList();
            Departments = DataBaseContext.Context().Departments.ToList();
            TypeHospitalizations = DataBaseContext.Context().TypeHospitalizations.ToList();
        }
        catch (Exception e)
        {
        }
    }
    /// <summary>
    /// Отмена госпитализации.
    /// </summary>
    public void CancelHospitalication()
    {
        try
        {
            if (Hospitalization.StatusHospitalizationId == 3)
                return;//Уведомление;
            Hospitalization.StatusHospitalization = StatusHospitalizations[2];
            DataBaseContext.Context().Hospitalizations.Update(Hospitalization);
            DataBaseContext.Context().SaveChanges();
            new HospitalizationViewModel(Hospitalization);
        }
        catch (Exception e)
        {
        }
    }
    /// <summary>
    /// Вернуться к введению кода госпитализации.
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner as MainViewModel).SelectedViewModel = Owner;
    }
}