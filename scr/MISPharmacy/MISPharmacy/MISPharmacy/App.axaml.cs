using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MISPharmacy.Service;
using MISPharmacy.ViewModels;
using MISPharmacy.Views;
using Refit;
using Splat;

namespace MISPharmacy;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        string host = "http://192.168.0.105:5141";
        Locator.CurrentMutable.Register(() => RestService.For<IDepartamentRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<IDistributionRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<IMedicationRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<IOrderRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<IPartyRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<ISupplierRepository>(host));
        Locator.CurrentMutable.Register(() => RestService.For<ISupplierRepository>(host));
        SplatRegistrations.RegisterLazySingleton<INotificationService, NotificationService>();
        SplatRegistrations.Register<MainViewModel>();
        SplatRegistrations.SetupIOC();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetService<MainViewModel>()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = Locator.Current.GetService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}