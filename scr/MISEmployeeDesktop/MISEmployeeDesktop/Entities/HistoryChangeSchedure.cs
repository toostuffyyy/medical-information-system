using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class HistoryChangeSchedure
{
    public int Id { get; set; }

    public int ScheduleEmployeeId { get; set; }

    public DateTime DateTimeChange { get; set; }

    public DateTime OldDate { get; set; }

    public DateTime OldTimeStart { get; set; }

    public DateTime OldTimeEnd { get; set; }

    public DateTime NewDate { get; set; }

    public DateTime NewTimeStart { get; set; }

    public DateTime NewTimeEnd { get; set; }

    public virtual ScheduleEmployee ScheduleEmployee { get; set; } = null!;
}
