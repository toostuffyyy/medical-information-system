using System;
using System.Collections.Generic;
using System.Linq;
using MISEmployeeDesktop.Context;
using MISEmployeeDesktop.Entities;

namespace MISEmployeeDesktop.ViewModels;

public class CreateMedicalEventViewModel : ViewModelBase
{
    public MedicalEvent MedicalEvent { get; set; }
    public MedicalCard MedicalCard {get; set; }
    public List<TypeMedicalEvent> TypeMedicalEvents { get; set; }
    public TypeMedicalEvent SelectedTypeMedicalEvents { get; set; }
    public CreateMedicalEventViewModel(MedicalCard medicalCard)
    {
        MedicalCard = medicalCard;
        MedicalEvent = new MedicalEvent()
        {
            DoctorId = DoctorId.Id, 
            MedicalCardNumber = medicalCard.Number, 
            StartDateTime = DateTime.Now,
            EndDateTime = DateTime.Now
        };
        TypeMedicalEvents = DataBaseContext.Context().TypeMedicalEvents.ToList();
    }
    /// <summary>
    /// Команда для выходв. 
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
    /// <summary>
    /// Создание мед события.
    /// </summary>
    public void CreateMedicalEvent()
    {
        try
        {
            if (SelectedTypeMedicalEvents != null)
                MedicalEvent.TypeMedicalEventId = SelectedTypeMedicalEvents.Id;
            MedicalCard.NextVisitDate = MedicalEvent.StartDateTime;
            
            DataBaseContext.Context().MedicalCards.Update(MedicalCard);
            DataBaseContext.Context().MedicalEvents.Add(MedicalEvent);
            DataBaseContext.Context().SaveChanges();
            (Owner.Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
        }
        catch (Exception e)
        {
        }
    }
}