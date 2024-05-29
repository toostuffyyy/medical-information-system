using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace MISSheduleEmployee.Converters;

public class TimeRangeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is TimeSpan startTime && values[1] is TimeSpan endTime)
            return $"{startTime:hh\\:mm} - {endTime:hh\\:mm}";
        return null;
    }
}