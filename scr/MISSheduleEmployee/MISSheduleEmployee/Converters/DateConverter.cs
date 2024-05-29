using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MISSheduleEmployee.Converters;

public class DateConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is DateTime date && values[1] is TimeSpan startTime && values[2] is TimeSpan endTime)
            return date.DayOfWeek.ToString() == (string)parameter ? $"{startTime:hh\\:mm} - {endTime:hh\\:mm}" : null;
        return null;
    }
}