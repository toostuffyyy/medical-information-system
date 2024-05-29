using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MISSheduleEmployee.Context;
using MISSheduleEmployee.Entities;
using ReactiveUI;

namespace MISSheduleEmployee.ViewModels;

public class ScheduleDayViewModel : ViewModelBase
{
    private DateTime _selectedDate;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set => this.RaiseAndSetIfChanged(ref _selectedDate, value);
    }
    private List<ScheduleEmployee> _scheduleEmployees;
    public List<ScheduleEmployee> ScheduleEmployees
    {
        get => _scheduleEmployees;
        set => this.RaiseAndSetIfChanged(ref _scheduleEmployees, value);
    }
    public List<Employee> Employees { get; set; }
    public Employee SelectedEmployee { get; set; }
    public List<Specialization> Specializations { get; set; }
    public Specialization SelectedSpecialization { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public ScheduleDayViewModel(DateTime date, Employee selectedEmployee, Specialization selectedSpecialization)
    {
        _selectedDate = date;
        SelectedEmployee = selectedEmployee;
        SelectedSpecialization = selectedSpecialization;
        
        Employees = DatabaseContext.Context.Employees.ToList();
        Employees.Insert(0, new Employee());
        Specializations = DatabaseContext.Context.Specializations.ToList();
        Specializations.Insert(0, new Specialization());
        UpdateDateGrid();
    }
    public void UpdateDateGrid()
    {
        var schedule = DatabaseContext.Context.ScheduleEmployees
            .Include(a => a.Employee)
            .ToList();
        
        if (SelectedEmployee != null && SelectedEmployee.Surname != null)
            schedule = schedule.Where(a => a.Employee.Surname == SelectedEmployee.Surname).ToList();
        else if (SelectedSpecialization != null && SelectedSpecialization.Name != null)
            schedule = schedule.Where(a => a.Employee.Specialization.Name == SelectedSpecialization.Name).ToList();
        else if (StartDate.Date < EndDate.Date)
            schedule = schedule.Where(a => a.Date >= StartDate.Date && a.Date <= EndDate.Date).ToList();

        schedule = schedule.Where(a => a.Date == SelectedDate.Date).ToList();
        
        ScheduleEmployees = schedule;
    }
    
    public void NextWeek()
    {
        SelectedDate = SelectedDate.AddDays(1);
        UpdateDateGrid();
    }
    public void PreviousWeek()
    {
        SelectedDate = SelectedDate.AddDays(-1);
        UpdateDateGrid();
    }
    public void SelectedDateNow()
    {
        SelectedDate = DateTime.Now.Date;
        UpdateDateGrid();
    }

    public void GoDayViewSchedule()
    {
        (Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
    /// <summary>
    /// Выход.
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner.Owner;
    }
}