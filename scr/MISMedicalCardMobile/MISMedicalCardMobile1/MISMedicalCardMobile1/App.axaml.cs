using System.Net.Http;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Avalonia.Notification;
using MISMedicalCardMobile1.Service;
using MISMedicalCardMobile1.ViewModels;
using MISMedicalCardMobile1.Views;
using Refit;
using Splat;

namespace MISMedicalCardMobile1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        const string host = "http://10.10.2.2:5171";
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<ITypeMedicalEventRepository>(host));
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<IInsuranceCompanyRepository>(host));
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<IGenderRepository>(host));
        Locator.CurrentMutable.RegisterLazySingleton(() => new HttpClient(), typeof(HttpClient));
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<IMedicalCardRepository>(host));
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<ISoundMessageRepository>(host));
        SplatRegistrations.RegisterLazySingleton<INotificationService, NotificationService>();
        SplatRegistrations.Register<MainViewModel>();
        SplatRegistrations.Register<AuthorizationViewModel>();
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
            singleViewPlatform.MainView = new MainView()
            {
                DataContext = Locator.Current.GetService<MainViewModel>()
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}