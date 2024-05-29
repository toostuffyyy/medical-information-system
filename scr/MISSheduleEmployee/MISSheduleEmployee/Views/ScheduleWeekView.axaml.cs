using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MISSheduleEmployee.ViewModels;

namespace MISSheduleEmployee.Views;

public partial class ScheduleWeekView : UserControl
{
    public ScheduleWeekView()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        (DataContext as ScheduleWeekViewModel).UpdateDateGrid();
    }

    private void CalendarDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        (DataContext as ScheduleWeekViewModel).UpdateDateGrid();
    }
}