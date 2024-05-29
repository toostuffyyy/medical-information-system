using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplication3.Services;
using AvaloniaApplication3.ViewModels;
using AvaloniaApplication3.Views;
using Refit;
using Splat;

namespace AvaloniaApplication3;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var host = "http://10.0.2.2:5189";
        SplatRegistrations.RegisterLazySingleton<ISoundService,SoundService>();
        Locator.CurrentMutable.RegisterLazySingleton(()=>RestService.For<ISoundMessageRepository>(host));
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