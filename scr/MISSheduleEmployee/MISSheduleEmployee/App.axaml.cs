using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using MISSheduleEmployee.Service;
using MISSheduleEmployee.ViewModels;
using MISSheduleEmployee.Views;
using Splat;

namespace MISSheduleEmployee;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        SplatRegistrations.RegisterLazySingleton<INotificationService, NotificationService>();
        SplatRegistrations.Register<MainWindowViewModel>();
        SplatRegistrations.SetupIOC();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetService<MainWindowViewModel>(),
            };
            Locator.Current.GetService<INotificationService>().Registration(new WindowNotificationManager(desktop.MainWindow));
        }

        base.OnFrameworkInitializationCompleted();
    }
}