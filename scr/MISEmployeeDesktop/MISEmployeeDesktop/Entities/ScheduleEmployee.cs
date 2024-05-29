using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class ScheduleEmployee
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public bool IsApproved { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<HistoryChangeSchedure> HistoryChangeSchedures { get; set; } = new List<HistoryChangeSchedure>();
}
