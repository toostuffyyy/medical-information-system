using System;
using System.Collections.Generic;
using System.Linq;
using MisBigBoartPatientWeb.Context;
using MisBigBoartPatientWeb.Entities;
using MisBigBoartPatientWeb.ViewModels;
using ReactiveUI;

namespace MisBigBoartPatientWeb.Views;

public class RegistrationViewModel : ViewModelBase
{
    public List<Gender> Genders { get; set; }
    public List<InsuranceCompany> InsuranceCompanies { get; set; }
    public InsuranceCompany SelectedInsuranceCompany { get; set; }
    public Gender SelectedGender { get; set; }
    public InsurancePolicy InsurancePolicy { get; set; }
    public Patient Patient { get; set; }
    public RegistrationViewModel()
    {
        Patient = new Patient() {DateOfBirth = DateTime.Now, Photo = "/Assets/template.png"};
        InsurancePolicy = new InsurancePolicy() {StartDate = DateTime.Now, EndDate = DateTime.Now};
        Genders = DataBaseContext.Context().Genders.ToList();
        InsuranceCompanies = DataBaseContext.Context().InsuranceCompanies.ToList();
    }
    /// <summary>
    /// Регистрация пациента.
    /// </summary>
    public void RegistrationPatient()
    {
        try
        {
            var patient = DataBaseContext.Context().Patients.FirstOrDefault(a =>
                a.PassportSeries == Patient.PassportSeries && a.PassportNumber == Patient.PassportNumber);
            if (patient == null)
            {
                if (SelectedGender != null && SelectedInsuranceCompany != null)
                {
                    Patient.GenderId = SelectedGender.Id;
                    InsurancePolicy.InsuranceCompanyId = SelectedInsuranceCompany.Id;
                    
                    DataBaseContext.Context().Patients.Add(Patient);
                    DataBaseContext.Context().SaveChanges();
                    
                    patient = DataBaseContext.Context().Patients.FirstOrDefault(a =>
                        a.PassportSeries == Patient.PassportSeries && a.PassportNumber == Patient.PassportNumber);
                    InsurancePolicy.PatientId = patient.Id;
                    var medicalCard = new MedicalCard() {PatientId = patient.Id, CreateDate = DateTime.Now, LastVisitDate = DateTime.Now};
                    
                    DataBaseContext.Context().InsurancePolicies.Add(InsurancePolicy);
                    DataBaseContext.Context().MedicalCards.Add(medicalCard);
                    DataBaseContext.Context().SaveChanges();
                    //Уведомление и переход на след форму.
                }
                else
                    return;//Уведомление.
            }
            else
                return; //Уведомление;
        }
        catch (Exception e)
        {
            //Соединение с бд.
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