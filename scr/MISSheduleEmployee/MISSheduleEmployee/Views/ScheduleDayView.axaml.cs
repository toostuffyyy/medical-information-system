using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MISSheduleEmployee.ViewModels;

namespace MISSheduleEmployee.Views;

public partial class ScheduleDayView : UserControl
{
    public ScheduleDayView()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        (DataContext as ScheduleDayViewModel).UpdateDateGrid();
    }

    private void CalendarDatePicker_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        (DataContext as ScheduleDayViewModel).UpdateDateGrid();
    }
}