using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MISEmployeeDesktop.ViewModels;
using MISEmployeeDesktop.Views;
using Refit;
using Splat;

namespace MISEmployeeDesktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Locator.CurrentMutable.RegisterLazySingleton(() => RestService.For<IPersonalLocationRepository>("http://127.0.0.1:8080"));
        SplatRegistrations.Register<MainWindowViewModel>();
        SplatRegistrations.SetupIOC();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Locator.Current.GetService<MainWindowViewModel>()
            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}