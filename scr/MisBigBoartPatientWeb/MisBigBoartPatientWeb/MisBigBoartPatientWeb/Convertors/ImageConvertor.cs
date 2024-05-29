using System;
using System.Globalization;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Splat;

namespace MisBigBoartPatientWeb.Convertors;

public class ImageConvertor : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string source && targetType.IsAssignableFrom(typeof(Bitmap)))
        {
            Uri uri;
            if (source.StartsWith("avares://"))
                uri = new Uri(source);
            else
            {
                string assemlyName = Assembly.GetEntryAssembly().GetName().Name;
                uri = new Uri($"avares://{assemlyName}/{source}");
            }
            return new Bitmap(Locator.Current.GetService<IAssetLoader>().Open(uri));
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}