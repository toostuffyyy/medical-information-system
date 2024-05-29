using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using MISSheduleEmployee.Context;
using MISSheduleEmployee.Entities;
using ReactiveUI;

namespace MISSheduleEmployee.ViewModels;

public class ScheduleWeekViewModel : ViewModelBase
{
    private DateTime _selectedDate = DateTime.Now;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set => this.RaiseAndSetIfChanged(ref _selectedDate, value);
    }
    private List<Employee> _scheduleEmploy;
    public List<Employee> ScheduleEmploy
    {
        get => _scheduleEmploy;
        set => this.RaiseAndSetIfChanged(ref _scheduleEmploy, value);
    }
    public List<Employee> Employees { get; set; }
    public Employee SelectedEmployee { get; set; }
    public List<Specialization> Specializations { get; set; }
    public Specialization SelectedSpecialization { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    
    public ScheduleWeekViewModel()
    {
        Employees = DatabaseContext.Context.Employees.ToList();
        Employees.Insert(0, new Employee());
        Specializations = DatabaseContext.Context.Specializations.ToList();
        Specializations.Insert(0, new Specialization());
        UpdateDateGrid();
    }

    public void UpdateDateGrid()
    {
        var schedule = DatabaseContext.Context.Employees
            .Include(a => a.ScheduleEmployees)
            .ToList();
        var mondayWeek = SelectedDate.AddDays(-(((int)SelectedDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7));
        
        if (SelectedEmployee != null && SelectedEmployee.Surname != null)
            schedule = schedule.Where(a => a.Surname == SelectedEmployee.Surname).ToList();
        else if (SelectedSpecialization != null && SelectedSpecialization.Name != null)
            schedule = schedule.Where(a => a.Specialization.Name == SelectedSpecialization.Name).ToList();
        else if (StartDate.Date < EndDate.Date)
            schedule = schedule
                .Where(a => a.ScheduleEmployees
                    .Any(a => a.Date >= StartDate.Date && a.Date <= EndDate.Date))
                    .ToList();
        
        schedule = schedule
            .Where(a => a.ScheduleEmployees.Count > 0)
            .Where(a => a.ScheduleEmployees
                .Any(a => a.Date >= mondayWeek.Date && a.Date <= mondayWeek.AddDays(6)))
                .ToList();

        // Создаем новые объекты для каждого дня недели, если их нет в списке
        foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            foreach (var sch in schedule)
            {
                if (sch.ScheduleEmployees.All(s => s.Date.DayOfWeek != (DayOfWeek)day))
                    sch.ScheduleEmployees.Add(new ScheduleEmployee());
                sch.ScheduleEmployees.Sort((s1, s2) => dayPositions[s1.Date.DayOfWeek].CompareTo(dayPositions[s2.Date.DayOfWeek]));
            }
        ScheduleEmploy = schedule;
    }
    
    Dictionary<DayOfWeek, int> dayPositions = new()
    {
        { DayOfWeek.Monday, 0 },
        { DayOfWeek.Tuesday, 1 },
        { DayOfWeek.Wednesday, 2 },
        { DayOfWeek.Thursday, 3 },
        { DayOfWeek.Friday, 4 },
        { DayOfWeek.Saturday, 5 },
        { DayOfWeek.Sunday, 6 }
    };
    public void NextWeek()
    {
        SelectedDate = SelectedDate.AddDays(7);
        UpdateDateGrid();
    }
    public void PreviousWeek()
    {
        SelectedDate = SelectedDate.AddDays(-7);
        UpdateDateGrid();
    }
    public void SelectedDateNow()
    {
        SelectedDate = DateTime.Now.Date;
        UpdateDateGrid();
    }

    public void GoDayViewSchedule()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = new ScheduleDayViewModel(SelectedDate, SelectedEmployee, SelectedSpecialization) { Owner = this };
    }
    /// <summary>
    /// Выход.
    /// </summary>
    public void GoBack()
    {
        (Owner.Owner as MainWindowViewModel).SelectedViewModel = Owner;
    }
}