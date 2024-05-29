using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MISSheduleEmployee.Context;
using MISSheduleEmployee.Entities;

namespace MISSheduleEmployee.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    public Employee Employee { get; set; }
    public AuthorizationViewModel()
    {
        Employee = new Employee();
    }
    /// <summary>
    /// Авторизация по уникальному значению.
    /// </summary>
    public void Authorization()
    {
        try
        {
            var employee = DatabaseContext.Context.Employees.FirstOrDefault(a => a.Id == Employee.Id);
            if (employee != null)
            {
                (Owner as MainWindowViewModel).SelectedViewModel = new ScheduleWeekViewModel() { Owner = this };
            }
        }
        catch (Exception e)
        {
        }
    }
}