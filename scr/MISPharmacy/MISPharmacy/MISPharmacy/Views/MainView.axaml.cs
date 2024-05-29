using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using MISPharmacy.Service;
using Splat;

namespace MISPharmacy.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        Locator.Current.GetService<INotificationService>()
            .Registration(new WindowNotificationManager(TopLevel.GetTopLevel(this)));
    }
}